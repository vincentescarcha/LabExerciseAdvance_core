using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExerciseAdvance
{
    [Table("Person")]
    public class Adult : Person
    {
        public Adult()
        {

        }
        public bool Employed { get; set; }
        public string JobTitle { get; set; }
    }
}
