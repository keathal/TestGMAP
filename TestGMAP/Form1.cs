using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Globalization;

namespace TestGMAP
{
    public partial class TestGMAP : Form
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();

        GMapOverlay mainOverlay = new GMapOverlay("DBmarkers");
        GMapOverlay polyOverlay = new GMapOverlay("Polygon");

        bool isLeftButtonDown = false;
        bool isChangedPosition = false;
        private GMapMarker currentMarker;

        public TestGMAP()
        {
            InitializeComponent();


            cli.getAllPositionsCompleted += Cli_getAllPositionsCompleted;
            cli.addRandomPositionCompleted += Cli_addRandomPositionCompleted;
            cli.editPositionCompleted += Cli_editPositionCompleted;

        }

        private void Cli_editPositionCompleted(object sender, ServiceReference1.editPositionCompletedEventArgs e)
        {
            gmap.Overlays.Remove(mainOverlay);
            cli.getAllPositionsAsync();
        }

        private void Cli_addRandomPositionCompleted(object sender, ServiceReference1.addRandomPositionCompletedEventArgs e)
        {
            gmap.Overlays.Remove(mainOverlay);
            cli.getAllPositionsAsync();
        }

        private void Cli_getAllPositionsCompleted(object sender, ServiceReference1.getAllPositionsCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                gmap.Overlays.Remove(mainOverlay);
                mainOverlay.Clear();

                foreach (ServiceReference1.T_Position item in e.Result)
                    mainOverlay.Markers.Add(positionToMarker(item));

                gmap.Overlays.Add(mainOverlay);
            }
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            gmap.Bearing = 0;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;

            gmap.GrayScaleMode = true;

            gmap.MarkersEnabled = true;
            gmap.MaxZoom = 18;
            gmap.MinZoom = 2;
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            gmap.NegativeMode = false;
            gmap.PolygonsEnabled = true;
            gmap.RoutesEnabled = true;
            gmap.ShowTileGridLines = false;
            gmap.Zoom = 10;
            gmap.ShowCenter = false;

            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(54.990104, 82.901561);

            cli.getAllPositionsAsync();

            drawPolygon(54.98f, 82.9f, 55f, 82.93f);
            
        }


        void drawPolygon(float x1, float y1, float x2, float y2)
        {
            List<PointLatLng> points = new List<PointLatLng>();

            points.Add(new PointLatLng(x1, y1));
            points.Add(new PointLatLng(x2, y1));
            points.Add(new PointLatLng(x2, y2));
            points.Add(new PointLatLng(x1, y2));


            var polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red);

            gmap.Overlays.Add(polyOverlay);
            polyOverlay.Polygons.Add(polygon);
        }


        GMarkerGoogle positionToMarker(ServiceReference1.T_Position item)
        {
            GMarkerGoogleType markerType;
            switch (item.T_MarkerType.color)
            {
                case "Red":
                    markerType = GMarkerGoogleType.red;
                    break;
                case "Blue":
                    markerType = GMarkerGoogleType.blue;
                    break;
                case "Yellow":
                    markerType = GMarkerGoogleType.yellow;
                    break;
                case "Green":
                    markerType = GMarkerGoogleType.green;
                    break;
                default:
                    markerType = GMarkerGoogleType.gray_small;
                    break;
            }
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(item.latitude, item.longtitude), markerType);
            marker.Tag = item.id_position;
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = item.T_TechUnit.name;
            return marker;
        }

        private void gmap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isLeftButtonDown)
            {
                if (currentMarker != null)
                {
                    PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
                    currentMarker.Position = point;
                    if (!isChangedPosition)
                        isChangedPosition = true;
                }
            }
        }

        private void gmap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftButtonDown = true;
        }

        private void gmap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isLeftButtonDown = false;

            //Проверка, был ли перемещен маркер
            if (isChangedPosition)
            {
                isChangedPosition = false;
                cli.editPositionAsync(Convert.ToInt32(currentMarker.Tag), (float)currentMarker.Position.Lat, (float)currentMarker.Position.Lng);
                if (isInPolygon(currentMarker, polyOverlay))
                {
                    ActionForm form = new ActionForm();
                    form.Tag = currentMarker.Tag;
                    form.x2y1 = gmap.ViewArea.LocationRightBottom;
                    form.x1y2 = gmap.ViewArea.LocationTopLeft;
                    form.ShowDialog();
                    cli.getAllPositionsAsync();
                }
                
            }
            currentMarker = null;
        }

        private void gmap_OnMarkerEnter(GMapMarker item)
        {
            if (!isLeftButtonDown)
                currentMarker = item;
        }

        private void gmap_OnMarkerLeave(GMapMarker item)
        {
            if(!isLeftButtonDown)
                currentMarker = null;
        }

        bool isInPolygon(GMapMarker marker, GMapOverlay overlay)
        {
            foreach (GMapPolygon polygon in overlay.Polygons)
            {
                if (polygon.IsInside(marker.Position))
                    return true;
            }

            return false;
        }

    }
}
