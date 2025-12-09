using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Models
{
    internal class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        
        public Mission() { }
    }
}
