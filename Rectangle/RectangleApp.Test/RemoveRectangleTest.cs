using RectangleApp.Models;
using RectangleApp.Services;
using Xunit;

namespace RectangleApp.Test
{
    public class RemoveRectangleTest
    {
        [Fact]
        public void Rectangle_RemoveRectangle_RectangleShouldNotBeRemovedIfItsNotAddedInGrid()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            Rectangle rectangle = new Rectangle(2, 2, 3, 3);
            gridService.AddRectangleInGrid(rectangle, grid);
            gridService.RemoveRectangleFromGrid(new Rectangle(3, 3, 3, 3), grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(new Rectangle(2, 1, 3, 3), grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(new Rectangle(1, 2, 3, 3), grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(new Rectangle(2, 2, 2, 3), grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(new Rectangle(2, 2, 3, 2), grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(null, grid);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));

            gridService.RemoveRectangleFromGrid(new Rectangle(2, 2, 3, 3), null);
            Assert.Contains(grid.Rectangles, item => item.Equals(rectangle));
        }

        [Fact]
        public void Rectangle_RemoveRectangle_RectangleShouldBeRemovedIfItsAddedInGrid()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            Rectangle rectangle = new Rectangle(2, 2, 3, 3);
            gridService.AddRectangleInGrid(rectangle, grid);
            gridService.RemoveRectangleFromGrid(new Rectangle(2, 2, 3, 3), grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));
        }
    }
}
