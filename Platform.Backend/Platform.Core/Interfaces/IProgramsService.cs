using Platform.Core.Entities;
using Platform.Core.Requests.ItemProgram;
using Platform.Core.Requests.Program;

namespace Platform.Core.Interfaces
{
    public interface IProgramsService
    {
        Task<ServiceResponse<List<ProgramDto>>> GetAll();

        Task<ServiceResponse<ProgramDto>> GetById(Guid id);

        Task<ServiceResponse<ProgramDto>> AddItem(AddItemProgramDto addItemProgram);

        Task<ServiceResponse<ProgramDto>> DeleteItem(Guid programId, int itemId);

        Task<ServiceResponse<ProgramDto>> ChangeItemOrder(Guid programId, int itemId, int orderNumber);
    }
}
