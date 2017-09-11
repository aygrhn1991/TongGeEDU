namespace TongGeEDU.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TongGeDB : DbContext
    {
        public TongGeDB()
            : base("name=TongGeDB")
        {
        }

        public virtual DbSet<tg_account_admin> tg_account_admin { get; set; }
        public virtual DbSet<tg_collapse> tg_collapse { get; set; }
        public virtual DbSet<tg_company> tg_company { get; set; }
        public virtual DbSet<tg_course> tg_course { get; set; }
        public virtual DbSet<tg_course_source> tg_course_source { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
