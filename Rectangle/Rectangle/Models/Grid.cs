using System.Collections.Generic;

namespace RectangleApp.Models
{
    public class Grid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public List<Rectangle> Rectangles { get; private set; }
        
        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            Rectangles = new List<Rectangle>();
        }
    }
}
