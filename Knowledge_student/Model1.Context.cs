﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Knowledge_student
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Knowledge_controlEntities : DbContext
    {
        public Knowledge_controlEntities()
            : base("name=Knowledge_controlEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Option_answers> Option_answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
    }
}
