//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bdDemoStudent
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activrtes
    {
        public int Id { get; set; }
        public System.DateTime LoginTime { get; set; }
        public Nullable<System.DateTime> LogoutTime { get; set; }
        public string Comment { get; set; }
        public Nullable<int> IdUser { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
