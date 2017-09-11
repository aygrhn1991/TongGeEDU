namespace TongGeEDU.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tg_course_source
    {
        public int id { get; set; }

        public int? parentid { get; set; }

        public int? chapter { get; set; }

        public string title { get; set; }

        public string filename { get; set; }
    }
}
