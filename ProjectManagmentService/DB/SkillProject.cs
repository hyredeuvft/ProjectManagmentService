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
    
    public partial class SkillProject
    {
        public int IdSkillProject { get; set; }
        public byte IdSkill { get; set; }
        public int IdProject { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
