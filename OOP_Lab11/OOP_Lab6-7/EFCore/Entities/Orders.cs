using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6_7.EFCore.Entities
{
    public class Orders
    {
        public Guid Id { get; set; }
        public Guid Id_User { get; set; }
        public Guid Id_Schedule { get; set; }

        [NotMapped]
        public Users User { get; set; }

       
    }
}
