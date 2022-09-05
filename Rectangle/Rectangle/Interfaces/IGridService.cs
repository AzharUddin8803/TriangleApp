using RectangleApp.Models;

namespace RectangleApp.Interfaces
{
    public interface IGridService
    {
        Grid CreateGrid(int height, int width);
        void AddRectangleInGrid(Rectangle rectangle, Grid grid);
        void RemoveRectangleFromGrid(Rectangle rectangle, Grid grid);
        Rectangle FindRectangleInGrid(int position_x, int position_y, Grid grid);
    }
}
