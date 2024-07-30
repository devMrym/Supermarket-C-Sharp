namespace ProDesign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table3
    {
        [StringLength(255)]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? price { get; set; }

        public int? quantity { get; set; }

        public virtual Table2 Table2 { get; set; }
    }
}
