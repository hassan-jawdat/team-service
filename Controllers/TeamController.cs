using Microsoft.AspNetCore.Mvc;
using TeamService.DTOs;
using TeamService.Services;

namespace TeamService.Controllers;

[ApiController]
[Route("api/team")]
public class TeamController(ITeamService teamService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var members = await teamService.GetAllAsync();
        return Ok(members);
    }

    [HttpPost("invite")]
    public async Task<IActionResult> Invite([FromBody] InviteDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
            return BadRequest("Email is required");

        var member = await teamService.InviteAsync(dto);
        return CreatedAtAction(nameof(GetAll), member);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await teamService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return Ok(new DeleteResponseDto("Member removed"));
    }
}
