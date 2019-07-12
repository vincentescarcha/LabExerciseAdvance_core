using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExerciseAdvance
{
    public static class Extensions
    {
        public static CityRepository cities = new CityRepository();
        public static bool TryParseTo<T>(this object value, Type conversionType, out T output)
        {
            output = default(T);
            try
            {
                output = (T)Convert.ChangeType(value, conversionType);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<IGrouping<string, PersonView>> Group(this IEnumerable<PersonView> persons, string groupingField)
        {
            var propertyInfo = typeof(PersonView).GetProperty(groupingField);
            return persons.GroupBy(x => propertyInfo.GetValue(x, null).ToString(),
                                        StringComparer.InvariantCultureIgnoreCase);
        }
        public static IEnumerable<PersonView> SearchByAge(this IEnumerable<PersonView> persons, int ageFrom, int ageTo)
        {
            return persons.Where(x => ageFrom <= x.Age && x.Age <= ageTo).ToList();
        }

        public static IEnumerable<PersonView> ToPersonView(this IEnumerable<Person> persons)
        {
            return persons.Join(cities.GetList, p => p.CityId, c => c.ID,
                (p, c) => new PersonView
                {
                    ID = p.ID,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DateOfBirth = p.DateOfBirth.ToString("MMM dd, yyyy"),
                    Age = p.Age,
                    Gender = p.Gender.ToString(),
                    Status = p.Status.ToString(),
                    PersonType = p.GetType().Name,
                    City = c.Name,
                    Province = c.Province,
                    Region = c.Region
                }
                );
        }
    }
}
