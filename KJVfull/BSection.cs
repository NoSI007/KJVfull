namespace KJVfull
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BSection")]
    public partial class BSection
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Book { get; set; }

        public int Chapter { get; set; }

        public int Section { get; set; }

        [StringLength(640)]
        public string Text { get; set; }

        public int? Old { get; set; }
    }
}
