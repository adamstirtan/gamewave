using System;

using Microsoft.AspNetCore.Identity;

namespace GameWave.ObjectModel
{
    public class ApplicationUser : IdentityUser
    {
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset LastModified { get; set; }
    }
}
