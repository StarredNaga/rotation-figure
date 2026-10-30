namespace RotationFigure;

public static class MathEngine
{
    public const double CharAspectRatio = 0.5d;
    public static Vector3d RotatePoint(Vector3d point, double xRotation, double yRotation, double zRotation)
    {
        xRotation *= (Math.PI / 180d);
        yRotation *= (Math.PI / 180d);
        zRotation *= (Math.PI / 180d);
    
        var sinA = Math.Sin(xRotation);
        var cosA = Math.Cos(xRotation);
    
        var sinB = Math.Sin(yRotation);
        var cosB = Math.Cos(yRotation);
    
        var sinC = Math.Sin(zRotation);
        var cosC = Math.Cos(zRotation);
    
        var x = point.X * cosB * cosC + point.Y * (-sinC * cosB) + point.Z * sinB;
    
        var y = point.X * (sinA * sinB * cosC + cosA * sinC) + point.Y * (-sinA * sinB * sinC + cosA * cosC) +
                point.Z * (-sinA * cosB);
    
        var z = point.X * (sinA * sinC - sinB * cosA * cosC) + point.Y * (sinA * cosC + sinB * sinC * cosA) + 
                point.Z * (cosA * cosB);
    
        return new Vector3d(x, y, z);
    }

    public static Vector2d ConvertTo2D(Vector3d point, double x, double y, double camDistance)
    {
        
        var transformedZ = point.Z + camDistance;

        if (transformedZ == 0) throw new DivideByZeroException();

        var screenX = (int)(point.X * camDistance / transformedZ + x);
        var screenY = (int)((point.Y * camDistance / transformedZ) * CharAspectRatio + y);
        
        return new Vector2d(screenX, screenY);
    }
}