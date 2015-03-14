﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DeedSimple.Domain
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string ContentType { get; set; }
    }
}
