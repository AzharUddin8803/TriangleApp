using RectangleApp.Models;
using RectangleApp.Services;
using Xunit;

namespace RectangleApp.Test
{
    public class FindRectangleTest
    {
        [Fact]
        public void Rectangle_FindRectangle_RectangleShouldNotBeFoundInGridForInValidData()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            gridService.AddRectangleInGrid(new Rectangle(2, 2, 3, 3), grid);

            Rectangle rectangle = gridService.FindRectangleInGrid(2, 2, grid);
            Assert.Null(rectangle);

            rectangle = gridService.FindRectangleInGrid(6, 6, grid);
            Assert.Null(rectangle);

            rectangle = gridService.FindRectangleInGrid(6, 2, grid);
            Assert.Null(rectangle);

            rectangle = gridService.FindRectangleInGrid(2, 6, grid);
            Assert.Null(rectangle);

            rectangle = gridService.FindRectangleInGrid(2, 6, null);
            Assert.Null(rectangle);
        }

        [Fact]
        public void Rectangle_FindRectangle_RectangleShouldBeFoundInGridForValidData()
        {
            GridService gridService = new GridService();
            Grid grid = gridService.CreateGrid(10, 10);

            gridService.AddRectangleInGrid(new Rectangle(2, 2, 3, 3), grid);

            Rectangle rectangle = gridService.FindRectangleInGrid(3, 3, grid);
            Assert.NotNull(rectangle);

            rectangle = gridService.FindRectangleInGrid(3, 4, grid);
            Assert.NotNull(rectangle);

            rectangle = gridService.FindRectangleInGrid(4, 3, grid);
            Assert.NotNull(rectangle);

            rectangle = gridService.FindRectangleInGrid(5, 5, grid);
            Assert.NotNull(rectangle);

            rectangle = gridService.FindRectangleInGrid(3, 5, grid);
            Assert.NotNull(rectangle);

            rectangle = gridService.FindRectangleInGrid(5, 3, grid);
            Assert.NotNull(rectangle);
        }
    }
}
