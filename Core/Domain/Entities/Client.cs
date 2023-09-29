using System;
using Domain.Common;

namespace Domain.Entities
{
   public class Client: AuditableBaseEntity
   {
    private int _age;
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int Age {
      get{
        if (this._age <= 0)
          this._age = new DateTime(DateTime.Now.Subtract(this.BirthDate).Ticks).Year - 1; 
        return this._age;
      }
    }
   } 
}
