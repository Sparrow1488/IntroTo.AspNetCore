﻿using System;

namespace AuthorizationNETCore.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
