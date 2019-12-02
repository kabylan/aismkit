using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{
    public class ListOfEducations
    {
        public int Id { get; set; }
        [Display(Name = "ИНН")]
        [Required(ErrorMessage = "ИНН обязательна")]
        public string INN { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование категории обязательна")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адрес обязательна")]
        public string Address { get; set; }
        [Display(Name = "Доменое имя")]
        public string DomenNames { get; set; }
        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCreated { get; set; }
        [Display(Name = "Категория")]
        public int ClUchZavedCategoryId { get; set; }
        public ClUchZavedCategory ClUchZavedCategory { get; set; }

    }

    // Модель для 
    // СПИСОК выданных государственных регистрационных удостоверений фильмам
    public class ListISRCFilms
    {
        public int Id { get; set; }

        [Display(Name = "Название фильма")]
        [Required(ErrorMessage = "Название фильма обязательна")]
        public string MovieTitle { get; set; }

        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Страна обязательна")]
        public string Country { get; set; }

        [Display(Name = "Год выпуска")]
        [Required(ErrorMessage = "Год выпуска обязательна")]
        public string ReleaseYear { get; set; }

        [Display(Name = "Режиссер")]
        [Required(ErrorMessage = "Режиссер обязательна")]
        public string Director { get; set; }

        [Display(Name = "Продолжительность")]
        [Required(ErrorMessage = "Продолжительность обязательна")]
        public string Duration { get; set; }

        [Display(Name = "Возрастные ограничения")]
        [Required(ErrorMessage = "Возрастные ограничения обязательна")]
        public string AgeRestrictions { get; set; }

        [Display(Name = "Дата выдачи удостоверения")]
        [Required(ErrorMessage = "Дата выдачи удостоверения обязательна")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCertificated { get; set; }
    }

}
