using Microsoft.EntityFrameworkCore;

namespace DormitorySystem.Data.Abstractions
{
    public interface ISeedUsers
    {
        void SeedAdmin(ModelBuilder builder);

        void SeedRole(ModelBuilder builder);
    }
}