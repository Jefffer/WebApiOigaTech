//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int idEmployee { get; set; }
        public string employeeName { get; set; }
        public string employeePhone { get; set; }
        public string employeePosition { get; set; }
        public int fk_ContractType { get; set; }
        public Nullable<decimal> hourlySalary { get; set; }
        public Nullable<decimal> monthlySalary { get; set; }
    
        public virtual ContractType ContractType { get; set; }
    }
}
