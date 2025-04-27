using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace aiTherapist.EntityFrameworkCore;

public static class aiTherapistDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<aiTherapistDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<aiTherapistDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
