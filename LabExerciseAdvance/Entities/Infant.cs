using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExerciseAdvance
{
    [Table("Person")]
    public class Infant : Person
    {
        public Infant()
        {

        }
        public string FavoriteFood { get; set; }
        public string FavoriteMilk { get; set; }

    }
}
