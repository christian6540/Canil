using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canil.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CanilUser class
    public class CanilUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Adress { get; set; }
    }
}