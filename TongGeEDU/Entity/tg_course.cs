namespace TongGeEDU.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tg_course
    {
        public int id { get; set; }

        public string grade { get; set; }

        public string subject { get; set; }

        public double? price { get; set; }

        public string title { get; set; }

        public string teacher { get; set; }

        public string introduction { get; set; }

        public string filename { get; set; }
    }
}
