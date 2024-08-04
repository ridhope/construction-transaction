using System.Collections.Generic;
using System.Threading.Tasks;
public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(Guid projectId);
    Task AddProjectAsync(Project project);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(Guid projectId);
}