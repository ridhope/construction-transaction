using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        var projects = await _projectRepository.GetAllProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(Guid id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<Project>> PostProject(Project project)
    {
        await _projectRepository.AddProjectAsync(project);
        return CreatedAtAction(nameof(GetProject), new { id = project.ProjectID }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProject(Guid id, Project project)
    {
        if (id != project.ProjectID)
        {
            return BadRequest();
        }

        await _projectRepository.UpdateProjectAsync(project);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await _projectRepository.DeleteProjectAsync(id);
        return NoContent();
    }
}