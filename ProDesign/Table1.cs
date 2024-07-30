namespace ProDesign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table1
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }
    }
}
