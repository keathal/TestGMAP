using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    public class Service1 : IService1
    {
        dbGMAPEntities db = new dbGMAPEntities();

        public bool addRandomPosition(float minLat, float minLong, float maxLat, float maxLong)
        {
            if (minLat > maxLat || minLong > maxLong)
                return false;

            Random rnd = new Random();
            T_Position item = new T_Position();
            item.latitude = maxLat - rnd.NextDouble() * (maxLat - minLat);
            item.longtitude = maxLong - rnd.NextDouble() * (maxLong - minLong);
            item.id_techUnit = 6;
            item.id_markerType = rnd.Next(1, db.T_MarkerType.Max(b => b.id_markerType));

            db.T_Position.Add(item);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool changeMarkerColor(int id)
        {
            if (id > 0)
            {
                T_Position item = db.T_Position.Where(b => b.id_position == id).FirstOrDefault();
                Random rnd = new Random();
                int curMarkerId = item.id_markerType;

                while (item.id_markerType == curMarkerId)
                    item.id_markerType = rnd.Next(1, db.T_MarkerType.Max(b => b.id_markerType));

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return false;
        }

        public bool editPosition(int id, float latitude, float longtitude)
        {
            if (id > 0)
            {
                T_Position item = db.T_Position.Where(b => b.id_position == id).FirstOrDefault();
                if (item == null)
                    return false;

                item.latitude = latitude;
                item.longtitude = longtitude;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return false;
        }

        public List<T_Position> getAllPositions()
        {
            List<T_Position> result = new List<T_Position>();
            foreach (T_Position item in db.T_Position)
            {
                T_Position temp = new T_Position();
                temp.id_position = item.id_position;
                temp.latitude = item.latitude;
                temp.longtitude = item.longtitude;
                temp.T_MarkerType = new T_MarkerType();
                temp.T_MarkerType.color = item.T_MarkerType.color;
                temp.T_TechUnit = new T_TechUnit();
                temp.T_TechUnit.name = item.T_TechUnit.name;

                result.Add(temp);
            }
            return result;
        }
    }
}
