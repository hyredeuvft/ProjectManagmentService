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
    
    public partial class VW_JobInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> CountTask { get; set; }
        public Nullable<decimal> CountHour { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }
        public Nullable<decimal> Salary { get; set; }
    }
}
