using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{
    // Здесь все дополнительные модели для модели Учебные Заведения
    // Модель Директор
    public class Director
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime ManagementStartDate { get; set; }

        public DateTime ManagementEndDate { get; set; }

        // Внешний ключ - ID учеб. заведения

        [Display(Name = "Учебное заведение")]
        public int? ListOfEducationsId { get; set; }

        public ListOfEducations listOfEducationsModel { get; set; }
    }

    // Модель Факультет
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Внешний ключ - ID учеб. заведения

        [Display(Name = "Учебное заведение")]
        public int? ListOfEducationsId { get; set; }
        public ListOfEducations listOfEducationsModel { get; set; }



        // список преподователей

        // образец диплома 

        // получаемя должность относительно каждой специальности
    }
    /*
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

    }

    // модель Литература
    public class Literature
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
    */
    // модель Сотрудник
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string PositionHeld { get; set; }

        // Внешний ключ - ID учеб. заведения

        [Display(Name = "Учебное заведение")]
        public int? ListOfEducationsId { get; set; }

        public ListOfEducations listOfEducationsModel { get; set; }

    }


}
