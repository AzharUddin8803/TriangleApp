using RectangleApp.Models;
using RectangleApp.Services;
using Xunit;

namespace RectangleApp.Test
{
    public class AddRectangleTest
    {
        [Fact]
        public void Rectangle_AddRectangle_InvalidRectangleIsNotAddedInGrid()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            Rectangle rectangle = new Rectangle(1, 1, -1, 0);
            gridService.AddRectangleInGrid(rectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));

            rectangle = new Rectangle(1, 1, 0, -1);
            gridService.AddRectangleInGrid(rectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));

            rectangle = new Rectangle(1, 1, -1, -1);
            gridService.AddRectangleInGrid(rectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));

            gridService.AddRectangleInGrid(null, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));

            rectangle = new Rectangle(1, 1, 1, 1);
            gridService.AddRectangleInGrid(rectangle, null);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));
        }

        [Fact]
        public void Rectangle_AddRectangle_RectangleOutsideGridIsNotAddedInGrid()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            Rectangle rectangle = new Rectangle(6, 6, 5, 5);
            gridService.AddRectangleInGrid(rectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));

            rectangle = new Rectangle(5, 5, 6, 6);
            gridService.AddRectangleInGrid(rectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(rectangle));
        }

        [Fact]
        public void Rectangle_AddRectangle_OverlapingRectangleIsNotAddedInGrid()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);
            Rectangle rectangle = new Rectangle(2, 2, 1, 1);
            gridService.AddRectangleInGrid(rectangle, grid);

            Rectangle overlapingRectangle = new Rectangle(2, 2, 1, 1);
            gridService.AddRectangleInGrid(overlapingRectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(overlapingRectangle));

            overlapingRectangle = new Rectangle(2, 2, 2, 2);
            gridService.AddRectangleInGrid(overlapingRectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(overlapingRectangle));

            overlapingRectangle = new Rectangle(2, 2, 0, 0);
            gridService.AddRectangleInGrid(overlapingRectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(overlapingRectangle));

            overlapingRectangle = new Rectangle(2, 2, 2, 0);
            gridService.AddRectangleInGrid(overlapingRectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(overlapingRectangle));

            overlapingRectangle = new Rectangle(2, 2, 0, 2);
            gridService.AddRectangleInGrid(overlapingRectangle, grid);
            Assert.DoesNotContain(grid.Rectangles, item => item.Equals(overlapingRectangle));
        }
    }
}
