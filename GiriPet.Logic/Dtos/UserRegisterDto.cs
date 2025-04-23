using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiriPet.Logic.Dtos
{
    public class UserRegisterDto
    {
        private string _email = null!;
        /// <summary>
        /// Full name of the user.
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Email address of the user.
        /// </summary>
        public string Email
        {
            get
            {
                return _email.ToLower();
            }
            set
            {
                _email = value.ToLower();
            }
        }

        /// <summary>
        /// Password chosen by the user.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; } = null!;
    }
}
