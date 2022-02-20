namespace KJVfull
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Matrix")]
    public partial class Matrix
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Book { get; set; }

        public int Chapter { get; set; }

        public int? LastSection { get; set; }
    }
}
