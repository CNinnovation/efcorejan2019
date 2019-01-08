using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstSample.Models
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        [Required()]
        public virtual Book Book { get; set; }
    }
}
