using System.Threading.Tasks;

namespace Data
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByNickname(string nickname);

        Task DeleteByNickname(string nickname);
    }
}
