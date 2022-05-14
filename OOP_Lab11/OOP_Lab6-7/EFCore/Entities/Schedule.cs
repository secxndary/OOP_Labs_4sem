using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6_7.EFCore.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid Id_Movie { get; set; }
        public DateTime DateTime { get; set; }

        [NotMapped]
        public Movie Movie { get; set; }
    }
}
