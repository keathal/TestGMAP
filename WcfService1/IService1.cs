using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<T_Position> getAllPositions();

        [OperationContract]
        bool editPosition(int id, float latitude, float longtitude);

        [OperationContract]
        bool addRandomPosition(float minLat, float minLong, float maxLat, float maxLong);

        [OperationContract]
        bool changeMarkerColor(int id);
    }
}
