using rectangle_app.Models;

namespace rectangle_app.Services;
public class RectangleService: IRectangleService
{
	private readonly RectangleContext _context;

	public RectangleService(RectangleContext context)
	{
		_context = context;
	}

	public List<ResultModel> CheckRectangle(IList<Rectangle> rectangles)
	{
		var result = new List<ResultModel>();

		foreach (var item in rectangles)
		{
			var fallingRectangles = _context.Rectangles
				.Where(r => (item.X >= r.X && item.X + item.Width <= r.X + r.Width)
						&& (item.Y >= r.Y && item.Y + item.Height <= r.Y + r.Height))
				.ToList();

			var rectangleResult = new ResultModel
			{
				Rectangle = item,
				FallInRectangles = fallingRectangles
			};

			result.Add(rectangleResult);
		}

		return result;
	}
}
