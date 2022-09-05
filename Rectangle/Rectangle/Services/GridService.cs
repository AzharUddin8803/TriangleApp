using RectangleApp.Interfaces;
using RectangleApp.Models;
using System.Linq;

namespace RectangleApp.Services
{
    public class GridService : IGridService
    {
        #region Constants
        const int minWidthAndHeight = 5;
        const int maxWidthAndHeight = 25;
        #endregion

        private RectangleService _rectangleService;
        private ValidatorService _validatorService;

        public GridService()
        {
            _rectangleService = new RectangleService();
            _validatorService = new ValidatorService();
        }

        #region Implement Interface
        public Grid CreateGrid(int height, int width)
        {
            return IsValid(height, width) ? new Grid(height, width) : null;
        }

        public void AddRectangleInGrid(Rectangle rectangle, Grid grid)
        {
            if (_rectangleService.IsValid(rectangle, grid))
            {
                grid.Rectangles.Add(rectangle);
            }
        }

        public void RemoveRectangleFromGrid(Rectangle rectangle, Grid grid)
        {
            if(_validatorService.IsObjectValid(rectangle)
                && _validatorService.IsObjectValid(grid))
            {
                grid.Rectangles
                .RemoveAll(r => r.Height == rectangle.Height
                    && r.Width == rectangle.Width
                    && r.Position_x == rectangle.Position_x
                    && r.Position_y == rectangle.Position_y);
            }
        }

        public Rectangle FindRectangleInGrid(int position_x, int position_y, Grid grid)
        {
            if (_validatorService.IsObjectValid(grid))
            {
                return grid.Rectangles
                .Where(r => position_x >= r.Position_x
                    && position_y >= r.Position_y
                    && position_x <= r.Position_x + r.Width
                    && position_y <= r.Position_y + r.Height)
                .FirstOrDefault();
            }
            return null;
        }
        #endregion

        #region helpers
        private bool IsValid(int height, int width)
        {
            return width >= minWidthAndHeight 
                && height >= minWidthAndHeight 
                && width <= maxWidthAndHeight 
                && height <= maxWidthAndHeight;
        }
        #endregion
    }
}
