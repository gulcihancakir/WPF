using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    class SignupModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public string UserPhone_Number { get; set; }
        public string UserAdress { get; set; }
        public string UserEmail { get; set; }

        public string UserParola { get; set; }
    }
}
