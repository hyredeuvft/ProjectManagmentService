//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagmentService.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timer
    {
        public int IdTimer { get; set; }
        public int IdEmployee { get; set; }
        public System.DateTime TimeStart { get; set; }
        public Nullable<System.DateTime> TimeEnd { get; set; }
        public Nullable<decimal> HourJob { get; set; }
        public Nullable<int> IdTask { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
