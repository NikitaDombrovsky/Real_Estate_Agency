//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agency
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public int Id { get; set; }
        public Nullable<int> Id_Distrcts { get; set; }
        public string Address_City { get; set; }
        public string Address_Street { get; set; }
        public Nullable<int> Address_House { get; set; }
        public Nullable<int> Address_Number { get; set; }
        public Nullable<int> Coordinate_latitude { get; set; }
        public Nullable<int> Coordinate_longitude { get; set; }
        public Nullable<int> TotalFloors { get; set; }
        public Nullable<int> TotalArea { get; set; }
    
        public virtual District District { get; set; }
    }
}
