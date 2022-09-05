using RectangleApp.Models;
using RectangleApp.Services;
using System;

namespace RectangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GridService gridService = new GridService();

            //Creating a Grid
            Grid grid = gridService.CreateGrid(3,4);

            //Placing rectangle in grid
            gridService.AddRectangleInGrid(new Rectangle(3, 4, 1, 1), grid);
            gridService.AddRectangleInGrid(new Rectangle(4, 6, 1, 1), grid);

            //Find rectangle
            Rectangle rectangle = gridService.FindRectangleInGrid(1, 1, grid);

            //Remove rectangle from grid
            gridService.RemoveRectangleFromGrid(rectangle, grid);

            Console.ReadKey();
        }
    }
}
