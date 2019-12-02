using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{
    //Виды объектнов культурного наследия
    public class ClOKNTypes
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование  обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }

    }

    //Виды услуг
    public class ClServices
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование услуги обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }

    }

    //Категории учебных заведений
    public class ClUchZavedCategory
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование категории обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }
    }

    //Категории произведений культуры и искусства
    public class ClObjProizIskusCategory
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование категории обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }

    }

    //Виды произведений культуры и искусства
    public class ClObjProizIskusTypes
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование вида обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }

    }

    //Виды наград
    public class ClNagradTypes
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование награды обязательна")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Desciption { get; set; }

    }

    public class Classificators
    {
    }

}
