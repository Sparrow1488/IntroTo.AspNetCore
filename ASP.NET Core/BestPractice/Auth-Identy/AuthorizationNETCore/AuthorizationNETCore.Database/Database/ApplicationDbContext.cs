using AuthorizationNETCore.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AuthorizationNETCore.Database.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
