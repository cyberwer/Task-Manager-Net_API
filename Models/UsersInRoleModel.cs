using System.Collections.Generic;

namespace DentalDDS_Api.Models
{
    //Not included in DbSet
    public class UsersInRoleModel
    {
        public string Id { get; set; }
        public List<string> EnrolledUsers { get; set; }
        public List<string> RemovedUsers { get; set; }

    }
}