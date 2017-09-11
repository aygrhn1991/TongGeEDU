namespace TongGeEDU.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tg_company
    {
        public int id { get; set; }

        public string filename { get; set; }

        public string url { get; set; }
    }
}
