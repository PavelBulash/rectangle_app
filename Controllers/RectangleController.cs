using Microsoft.AspNetCore.Mvc;
using rectangle_app.Services;

namespace rectangle_app.Controllers;
public class RectangleController : ControllerBase
{
	private readonly RectangleContext _context;
	private readonly IRectangleService _rectangleService;

	public RectangleController(RectangleContext context, IRectangleService rectangleService)
	{
		_context = context;
		_rectangleService = rectangleService;
	}

	[HttpPost("findRectangles")]
	public IActionResult FindRectangles([FromBody] List<Rectangle> inputRectangles)
	{
		if (inputRectangles == null || !inputRectangles.Any())
		{
			return BadRequest("Invalid Rectangles.");
		}

		var result = _rectangleService.CheckRectangle(inputRectangles);

		return Ok(result);
	}
}
