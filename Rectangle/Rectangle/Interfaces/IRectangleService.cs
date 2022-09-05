using RectangleApp.Models;

namespace RectangleApp.Interfaces
{
    public interface IRectangleService
    {
        bool IsValid(Rectangle rectangle, Grid grid);
    }
}
