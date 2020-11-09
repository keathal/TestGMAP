using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGMAP
{
    public partial class ActionForm : Form
    {
        public PointLatLng x1y2, x2y1;
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        
        public ActionForm()
        {
            InitializeComponent();

            cli.addRandomPositionCompleted += Cli_addRandomPositionCompleted;
            cli.changeMarkerColorCompleted += Cli_changeMarkerColorCompleted;
        }

        private void Cli_changeMarkerColorCompleted(object sender, ServiceReference1.changeMarkerColorCompletedEventArgs e)
        {
            Close();
        }

        private void Cli_addRandomPositionCompleted(object sender, ServiceReference1.addRandomPositionCompletedEventArgs e)
        {
            Close();
        }

        private void b_addRandom_Click(object sender, EventArgs e)
        {
            cli.addRandomPositionAsync((float)x2y1.Lat, (float)x1y2.Lng, (float)x1y2.Lat, (float)x2y1.Lng);
        }

        private void b_dialog_Click(object sender, EventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show("Confirm action",
                               "Dialog Form",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information);
            Close();
        }

        private void b_changeColor_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Tag);
            if (id > 0)
                cli.changeMarkerColorAsync(id);
        }
    }
}
