using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Models
{
    public class UserListModel
    {
        public UserListModel()
        {
            UserList = new List<UserModel>();
        }
        
        public List<UserModel> UserList { get; set; }
    }
}