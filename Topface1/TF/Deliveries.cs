//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topface1.TF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deliveries
    {
        public int ID_Deliveries { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Supplier { get; set; }
        public Nullable<int> ID_Employee { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
