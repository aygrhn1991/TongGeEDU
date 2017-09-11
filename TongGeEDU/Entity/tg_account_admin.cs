namespace TongGeEDU.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tg_account_admin
    {
        public int id { get; set; }

        public string account { get; set; }

        public string password { get; set; }
    }
}
