using Xunit;
using RectangleApp.Models;
using RectangleApp.Services;

namespace RectangleApp.Test
{
    public class CreateGridTest
    {
        [Fact]
        public void Grid_CreateGrid_InvalidGridNotCreated()
        {
            GridService gridService = new GridService();

            Grid grid = gridService.CreateGrid(4, 4);
            Assert.Null(grid);

            grid = gridService.CreateGrid(5, 4);
            Assert.Null(grid);

            grid = gridService.CreateGrid(26, 6);
            Assert.Null(grid);

            grid = gridService.CreateGrid(6, 26);
            Assert.Null(grid);

            grid = gridService.CreateGrid(26, 26);
            Assert.Null(grid);
        }

        [Fact]
        public void Grid_CreateGrid_ValidGridIsCreated()
        {
            GridService gridService = new GridService();

            Grid grid = gridService.CreateGrid(5, 5);
            Assert.NotNull(grid);

            grid = gridService.CreateGrid(25, 25);
            Assert.NotNull(grid);

            grid = gridService.CreateGrid(15, 20);
            Assert.NotNull(grid);

            grid = gridService.CreateGrid(20, 15);
            Assert.NotNull(grid);
        }
    }
}
