namespace ProDesign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table2
    {
        [StringLength(255)]
        public string ID { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string category { get; set; }

        [StringLength(50)]
        public string brand { get; set; }

        public int? price { get; set; }

        public int? quantity { get; set; }

        public virtual Table3 Table3 { get; set; }
    }
}
