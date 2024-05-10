using ProjectManagmentService.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentService.ClassHelper
{
    public class EFClass
    {
        public static Entities Context { get; set; } = new Entities();
    }
}
