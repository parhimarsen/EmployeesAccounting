using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesAccounting.Models
{
    public class Department
    {
        //Id Отдела
        [Required]
        [Key]
        [Index(IsUnique = true)]
        [Column(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        //Название отдела
        [Required]
        [Column(nameof(Name))]
        public string Name { get; set; }

        //Дата добавления отдела
        [Required]
        [Column(nameof(DateOfAdding))]
        public string DateOfAdding { get; set; }

        //Дата изменения информации по отделу
        [Required]
        [Column(nameof(DateInfoChanging))]
        public string DateInfoChanging { get; set; }

        //Список сотрудником отдела
        [ForeignKey("DepartmentId")]
        public ICollection<Employee> Employees { get; set; }
    }
}