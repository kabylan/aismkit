using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{
    // Здесь все дополнительные модели для модели Учебные Заведения
    
    // Модель Факультет
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // внешний ключ это Учебное заведение
        public int? ListOfEducationsId { get; set; }

        public ListOfEducations listOfEducationsModel { get; set; }
    }
    
    // модель Сотрудник
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FullName { get { return FirstName + " " + SecondName; } set { } }

    }

    // модель Должность
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    // модель-промежуточный для Сотрудник-Должность
    public class EmplPosHistory
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int? PositionId { get; set; }

        public Position Position { get; set; }

        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }
   
    // модель Специальность
    public class Specialty
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    // модель-промежуточный для Факультет-Специальность 
    public class FacultySpecialty
    {
        public int Id { get; set; }

        public int? SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }

    // модель Подразделение (Учебного заведения)
    public class EducationalUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    // модель-промежуточный для Сотрудник-Подразделение
    public class EmplEducationalUnit
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int? EducationalUnitId { get; set; }

        public EducationalUnit EducationalUnit { get; set; }
    }


}
