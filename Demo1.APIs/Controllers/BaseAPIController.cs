using Microsoft.AspNetCore.Mvc;

namespace Demo1.APIs.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public abstract class BaseAPIController : ControllerBase
	{

	}
}
