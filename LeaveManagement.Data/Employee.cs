using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Data
{
    public class Employee : IdentityUser
    {
        //De esta manera se agrega a AspNetUsers heredando solamente IdentityUser,
        //y reemplazando este ultimo con Employee donde corresponde
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
        
        public string? TaxId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
