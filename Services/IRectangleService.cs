using rectangle_app.Models;

namespace rectangle_app.Services;
public interface IRectangleService
{
	List<ResultModel> CheckRectangle(IList<Rectangle> rectangle);
}
