namespace RotationFigure;

public struct Vector2d
{
    public double X { get; set; }
    
    public double Y { get; set; }

    public Vector2d()
    {
        X = 0.0;
        Y = 0.0;
    }

    public Vector2d(double x, double y)
    {
        X = x;
        Y = y;
    }
}