using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LabExerciseAdvance
{
    public class Registration
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public ICollection<Person> Persons { get; set; }

    }
}
