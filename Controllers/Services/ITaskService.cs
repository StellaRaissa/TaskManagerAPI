using TaskManagerAPI.DTOs;

namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIdAsync(int id);
        Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
        Task<bool> UpdateAsync(int id, TaskUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
