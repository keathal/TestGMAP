//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Position
    {
        public int id_position { get; set; }
        public int id_techUnit { get; set; }
        public int id_markerType { get; set; }
        public double latitude { get; set; }
        public double longtitude { get; set; }
    
        public virtual T_MarkerType T_MarkerType { get; set; }
        public virtual T_TechUnit T_TechUnit { get; set; }
    }
}
