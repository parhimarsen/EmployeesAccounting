using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeesAccounting.Models
{
    public class Employee
    {
        //Id Сотрудника
        [Key]
        [Index(IsUnique = true)]
        [Required]
        [Column(nameof(EmployeeId))]
        public int EmployeeId { get; set; }

        //ФИО Сотрудника
        [Required]
        [Column(nameof(Name))]
        public string Name { get; set; }

        //Дата добавления сотрудника
        [Required]
        [Column(nameof(DateOfAdding))]
        public string DateOfAdding { get; set; }

        //Дата изменения информации о сотруднике
        [Required]
        [Column(nameof(DateInfoChanging))]
        public string DateInfoChanging { get; set; }

        //Дата найма
        [Required]
        [Column(nameof(DateOfEmployment))]
        public string DateOfEmployment { get; set; }

        //Id Отдела
        [Required]
        [Column(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        //Отдел
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

    }
}