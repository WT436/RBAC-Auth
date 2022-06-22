﻿using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class UserPassword
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public bool IsActived { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
