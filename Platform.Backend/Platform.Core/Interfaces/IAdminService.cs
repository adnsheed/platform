using Platform.Core.Entities;
using Platform.Core.Requests.Admin;

namespace Platform.Core.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResponse<Report>> Report();
    }
}
