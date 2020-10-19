using System.Threading.Tasks;

namespace ProductPriceTracking.Bll.Interfaces
{
    public interface IUserRoleService
    {
        Task<bool> CheckUserRole(int userId, int roleId);
    }
}
