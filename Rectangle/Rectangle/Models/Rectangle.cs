namespace RectangleApp.Models
{
    public class Rectangle
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Position_x { get; private set; }
        public int Position_y { get; private set; }

        public Rectangle(int height, int width, int position_x, int position_y)
        {
            Height = height;
            Width = width;
            Position_x = position_x;
            Position_y = position_y;
        }
    }
}
