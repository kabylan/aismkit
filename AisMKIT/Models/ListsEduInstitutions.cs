using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{
    public class ListsEduInstitutions
    {
        public EduInstitution EduInstitution { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<FacultySpecialty> FacultySpecialties { get; set; }
        public IEnumerable<EmplPosHistory> EmplPosHistories { get; set; }
        public IEnumerable<EmplEducationalUnit> EmplEducationalUnits { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<EducationalUnit> EducationalUnits { get; set; }

    }
}
