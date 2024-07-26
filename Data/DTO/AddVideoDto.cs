using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class AddVideoDto
    {
        public int VideoId { get; set; }
        public int  CategoryId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime PublishedOn { get; set; }
       

    }
}
