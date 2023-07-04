using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Animal { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public virtual Customer Customer { get; set; }
        [NotMapped]
        public virtual ICollection<Jab> Jabs { get; set; }
        [NotMapped]
        public int CustomerId { get; set; }
        public Pet()
        {
            //Jabs = new HashSet<Jab>();
        }
        
    }
}
