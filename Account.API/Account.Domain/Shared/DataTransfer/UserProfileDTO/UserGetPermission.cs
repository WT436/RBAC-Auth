using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Shared.DataTransfer.UserProfileDTO
{
    public class UserGetPermission
    {
        public string Atomic { get; set; }
        public string Resource { get; set; }
        public int Type { get; set; }
    }
}
