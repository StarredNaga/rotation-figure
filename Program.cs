
using System.Text;
using RotationFigure;

Console.CursorVisible = false;

Console.OutputEncoding = Encoding.UTF8;

var width = Console.WindowWidth;
var height = Console.WindowHeight;

const char drawSymbol = '*';
const char emptySymbol = ' ';

var render = new RenderEngine(width, height, drawSymbol, emptySymbol);

const double camDistance = 40d;

const int renderTimeout = 5;

var points = FigureEngine.CreateCircle(0d, 0d, 0d, 20d, 15);

var transformedPoints = new List<Vector2d>();

var xAngle = 0d;
var yAngle = 0d;
var zAngle = 0d;

const double xAngleSpeed = 2d;
const double yAngleSpeed = 2d;
const double zAngleSpeed = 2d;

try
{
    while (true)
    {
        if (Console.WindowHeight != height || Console.WindowWidth != width)
        {
            render.ResizeBuffer(Console.WindowWidth, Console.WindowHeight);
            
            width = Console.WindowWidth;
            height = Console.WindowHeight;
        }
        
        transformedPoints.Clear();

        xAngle += xAngleSpeed;
        yAngle += yAngleSpeed;
        zAngle += zAngleSpeed;
        
        xAngle %= 360;
        yAngle %= 360;
        zAngle %= 360;

        foreach (var point in points)
        {
            var rotated = MathEngine.RotatePoint(point, xAngle, yAngle, zAngle);

            transformedPoints.Add(MathEngine.ConvertTo2D(rotated, width / 2d, height / 2d, camDistance));
        }

        render.Render(transformedPoints);

        Thread.Sleep(renderTimeout);
    }
}
finally
{
    Console.Clear();
    
    Console.CursorVisible = true;
    
    Console.OutputEncoding = Encoding.Default;
}


 
