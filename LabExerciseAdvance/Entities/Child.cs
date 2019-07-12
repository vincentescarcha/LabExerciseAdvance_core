using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExerciseAdvance
{
    [Table("Person")]
    public class Child : Person
    {
        public Child()
        {

        }
        public string School { get; set; }
        public string Level { get; set; }
    }
}
