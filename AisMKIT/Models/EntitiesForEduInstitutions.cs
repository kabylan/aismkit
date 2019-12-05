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

        [Display(Name = "Наименование факультета")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        // внешний ключ это Учебное заведение

        [Display(Name = "Учебное заведение")]
        public int? EduInstitutionId { get; set; }

        [Display(Name = "Учебное заведение")]
        public EduInstitution EduInstitution { get; set; }
    }

    // модель Специальность
    public class Specialty
    {
        public int Id { get; set; }

        [Display(Name = "Специальность")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }

    // модель-промежуточный для Факультет-Специальность 
    public class FacultySpecialty
    {
        public int Id { get; set; }


        [Display(Name = "Специальность")]
        public int? SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }


        [Display(Name = "Факультет")]
        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }

    // модель Сотрудник
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }


        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }


        [Display(Name = "ФИО")]
        public string FullName { get { return FirstName + " " + SecondName; } set { } }

    }

    // модель Должность
    public class Position
    {
        public int Id { get; set; }

        [Display(Name = "Должность")]
        public string Name { get; set; }
    }

    // модель-промежуточный для Сотрудник-Должность
    public class EmplPosHistory
    {
        public int Id { get; set; }

        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }


        [Display(Name = "Должность")]
        public int? PositionId { get; set; }

        public Position Position { get; set; }

        [Display(Name = "Начало работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime WorkStartDate { get; set; }

        [Display(Name = "Конец работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime WorkEndDate { get; set; }



        [Display(Name = "Факультет")]
        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }
   

    // модель Подразделение (Учебного заведения)
    public class EducationalUnit
    {
        public int Id { get; set; }

        [Display(Name = "Подразделение")]
        public string Name { get; set; }
    }

    // модель-промежуточный для Сотрудник-Подразделение
    public class EmplEducationalUnit
    {
        public int Id { get; set; }

        [Display(Name = "Сотрудник")]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Подразделение")]
        public int? EducationalUnitId { get; set; }

        public EducationalUnit EducationalUnit { get; set; }


        [Display(Name = "Начало работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime WorkStartDate { get; set; }

        [Display(Name = "Конец работы")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime WorkEndDate { get; set; }

        [Display(Name = "Факультет")]
        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }
    }


}
