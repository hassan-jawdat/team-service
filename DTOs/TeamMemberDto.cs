namespace TeamService.DTOs;

public record TeamMemberDto(int Id, string Name, string Email, string Role);

public record InviteDto(string Email);

public record DeleteResponseDto(string Message);
