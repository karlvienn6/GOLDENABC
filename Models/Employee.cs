using System.ComponentModel.DataAnnotations;

namespace mysqlefcore;

public class Employee {
    
    [Key]
    public int? employeeId {get;set;}
    public string? lastName {get; set;}
    public string? firstName{get; set;}
    public string? middleName{get; set;}
    public string? dateHired{get; set;}
}