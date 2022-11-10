using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Requests.Selection;

namespace Platform.Core.Interfaces
{
    public interface ISelectionsService
    {
        Task<ServiceResponse<List<SelectionDto>>> GetAll(RequestParameters selectionParameters);
        Task<ServiceResponse<SelectionDto>> GetById(Guid id);
        Task<ServiceResponse<SelectionDto>> Create(CreateSelectionDto newSelection);
        Task<ServiceResponse<SelectionDto>> Update(Guid id, UpdateSelectionDto updatedSelection);
        Task<ServiceResponse<SelectionDto>> AddStudent(Guid slectionId, int studentId, Guid programId);
        Task<ServiceResponse<SelectionDto>> RemoveStudent(Guid slectionId, int studentId);
        Task<ServiceResponse<List<SelectionDto>>> Delete(Guid id);
    }
}
