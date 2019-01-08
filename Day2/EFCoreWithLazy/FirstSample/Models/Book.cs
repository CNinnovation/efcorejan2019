using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FirstSample.Models
{

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public virtual List<Chapter> Chapters { get; set; } = new List<Chapter>();

        public override string ToString() => Title;
    }
}
