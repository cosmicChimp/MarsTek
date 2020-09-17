using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarsTek.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string InfoBody { get; set; }
        public string PicUrl { get; set; }
    }
}
