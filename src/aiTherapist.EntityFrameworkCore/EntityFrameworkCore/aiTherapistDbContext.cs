using Abp.Zero.EntityFrameworkCore;
using aiTherapist.Authorization.Roles;
using aiTherapist.Authorization.Users;
using aiTherapist.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace aiTherapist.EntityFrameworkCore;

public class aiTherapistDbContext : AbpZeroDbContext<Tenant, Role, User, aiTherapistDbContext>
{
    /* Define a DbSet for each entity of the application */

    public aiTherapistDbContext(DbContextOptions<aiTherapistDbContext> options)
        : base(options)
    {
    }
}
