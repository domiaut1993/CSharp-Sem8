using System;

public abstract class Shape
{
    internal static class Colors
    {
        public static int Blue = 1;
        public static int Red = 2;
        public static int Green = 3;
    }

    private int color;

    public int Color
    {
        get
        {
            if (color == 0xFF0000) return Colors.Red;
            if (color == 0x00FF00) return Colors.Green;
            if (color == 0x0000FF) return Colors.Blue;

            return 0;
        }
        set
        {
            switch (value)
            {
                case 1:
                    color = 0x0000FF;
                    break;
                case 2:
                    color = 0xFF0000;
                    break;
                case 3:
                    color = 0x00FF00;
                    break;
                default:
                    throw new ArgumentException("Стойността трябва да бъде между 1 и 3.");
            }
        }
    }
    public abstract double Area();
    public abstract double Circ();

}
