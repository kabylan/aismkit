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

        // список директаров 
        public IEnumerable<Director> ListDirectors { get; set; }

        // список факультетов 
        public IEnumerable<Faculty> ListFaculties { get; set; }

        // список сотрудников
        public IEnumerable<Employee> ListEmployees { get; set; }
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
    /*
    // учебное заведение

    public class EduInstitution
    {
        public int Id { get; set; }

        [Display(Name = "ИНН")]
        [Required(ErrorMessage = "")]
        public string TIN { get; set; }

        [Display(Name = "Наименованин заведения")]
        [Required(ErrorMessage = "")]
        public string Name { get; set; }

        [Display(Name = "Юридический адрес")]
        [Required(ErrorMessage = "")]
        public string Address { get; set; }

        [Display(Name = "Доменное  имя  (е-mail ) ")]
        [Required(ErrorMessage = "")]
        public string DomainEmail { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "")]
        public string Category { get; set; }

        [Display(Name = "Дата основания")]
        [Required(ErrorMessage = "")]
        public string Established { get; set; }

    }
    */
    // библиотека

    public class Library
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Дата создания")]
        public string Established { get; set; }

        [Display(Name = "Общий книжный фонд")]
        public string GeneralBookFund { get; set; }

        [Display(Name = "Количество читателе")]
        public int NumberReaders { get; set; }

        [Display(Name = "Количество библиотечных работников")]
        public int NumberWorkers { get; set; }

        [Display(Name = "Показатели библиотечной статистики (книговыдача)")]
        public int LibraryStat { get; set; }

    }

    // охраняемый объект культурного наследия

    public class CultHeritage
    {
        public int Id { get; set; }

        [Display(Name = "Наименование ")]
        public string Name { get; set; }

        [Display(Name = "Краткая информация ")]
        public string ShortInfo { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Вид")]
        public string Kind { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Date { get; set; }
    }


    // объект произведения культуры или искусства

    public class CultObjectAndArt
    {
        public int Id { get; set; }

        [Display(Name = "Наименование ")]
        public string Name { get; set; }

        [Display(Name = "Краткая информация ")]
        public string ShortInfo { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Вид")]
        public string Kind { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Date { get; set; }

    }

    

    // подведомственное учреждение Министерства

    public class SubInstitution
    {
        public int Id { get; set; }

        [Display(Name = "ИНН")]
        public string TIN { get; set; }

        [Display(Name = "Наименование учреждения")]
        public string Name { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        [Display(Name = "Контактные данные")]
        public string Contact { get; set; }

        [Display(Name = "Доменное имя(если есть)")]
        public string DomainEmail { get; set; }

        [Display(Name = "Краткая информация")]
        public string ShortInfo { get; set; }

        [Display(Name = "Категория учреждения")]
        public string Category { get; set; }
    }


    // государственная или ведомственная награда

    public class Award
    {
        public int Id { get; set; }

        [Display(Name = "Наименование награды")]
        public string Name { get; set; }

        [Display(Name = "Даты выдачи")]
        public string AwardDate { get; set; }

        [Display(Name = "Описания заслуг")]
        public string DescMerit { get; set; }

        public List<AwardedPerson> AwardedPersons { get; set; }
    }

    // персональные данные награжденного

    public class AwardedPerson
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string CardId { get; set; }
    }
}
