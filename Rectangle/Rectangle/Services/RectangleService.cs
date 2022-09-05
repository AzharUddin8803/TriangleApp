using RectangleApp.Interfaces;
using RectangleApp.Models;

namespace RectangleApp.Services
{
    public class RectangleService : IRectangleService
    {
        private ValidatorService _validatorService;

        public RectangleService()
        {
            _validatorService = new ValidatorService();
        }
        #region Implement Interface
        public bool IsValid(Rectangle rectangle, Grid grid)
        {
            return _validatorService.IsObjectValid(rectangle)
                && _validatorService.IsObjectValid(grid)
                && AreRectangleCoOrdinatesValid(rectangle)
                && IsRectangleInsideGrid(rectangle, grid)
                && !DoesRectangleHaveOverlapingRectangle(rectangle, grid);
        }
        #endregion

        #region Helpers
        private bool AreRectangleCoOrdinatesValid(Rectangle rectangle)
        {
            return rectangle.Position_x >= 0 && rectangle.Position_y >= 0;
        }

        private bool IsRectangleInsideGrid(Rectangle rectangle, Grid grid)
        {
            return rectangle.Position_x + rectangle.Width <= grid.Width
                && rectangle.Position_y + rectangle.Height <= grid.Height;
        }

        private bool DoesRectangleHaveOverlapingRectangle(Rectangle rectangle, Grid grid)
        {
            int rectangle_x1 = rectangle.Position_x;
            int rectangle_y1 = rectangle.Position_y;
            int rectangle_x2 = rectangle.Position_x + rectangle.Width;
            int rectangle_y2 = rectangle.Position_y + rectangle.Height;

            foreach (var item in grid.Rectangles)
            {
                int item_x1 = item.Position_x;
                int item_y1 = item.Position_y;
                int item_x2 = item.Position_x + item.Width;
                int item_y2 = item.Position_y + rectangle.Height;

                if (rectangle_x1 < item_x2
                    && rectangle_x2 > item_x1 
                    && rectangle_y1 < item_y2
                    && rectangle_y2 > item_y1)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
