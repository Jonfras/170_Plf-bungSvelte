namespace DepartmentsBackend.Controllers;

public record struct OkStatus(bool IsOk, int Nr, string? Error = null);

[Route("[controller]")]
[ApiController]
public class ValuesController(DepartmentsContext db) : ControllerBase
{	
  
  [HttpGet("Skills")]
  public OkStatus GetSkills()
  {
    this.Log();
    try
    {
  	  int nr = db.Skills.Count();
  	  return new OkStatus(true, nr);
    }
    catch (Exception exc)
    {
  	  return new OkStatus(false, -1, exc.Message);
    }
  }
}
