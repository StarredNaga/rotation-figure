namespace RotationFigure;

public static class FigureEngine
{
    public static List<Vector3d> CreateCircle(double x, double y, double z, double radius, int segments)
    {
        var points = new List<Vector3d>();
    
        var angleChange = 2 * Math.PI / segments;

        for (var i = 0; i < segments; i++)
        {
            var angleCos = Math.Cos(angleChange * i);
            var angleSin = Math.Sin(angleChange * i);
            
            var px = x + radius * angleCos;
            var py = y + radius * angleSin;
            var pz = z;
        
            points.Add(new Vector3d(px, py, pz));
        }
    
        return points;
    }

    public static List<Vector3d> CreateSphere(double x, double y, double z, double radius,
        int thetaSegments, int phiSegments)
    {
        var points = new List<Vector3d>();
        
        var thetaAngle = Math.PI / thetaSegments;
        var phiAngle = 2 * Math.PI / phiSegments;
        
        for (var i = -thetaSegments; i <= thetaSegments; i++)
        {
            var thetaCos = Math.Cos(thetaAngle * i);
            var thetaSin = Math.Sin(thetaAngle * i);
            
            for (var j = 0; j < phiSegments; j++)
            {
                var px = x + radius * thetaCos * Math.Cos(phiAngle * j);
                var py = y + radius * thetaSin;
                var pz = z + radius * thetaCos * Math.Sin(phiAngle * j);
                
                points.Add(new Vector3d(px, py, pz));
            }
        }
        
        return points;
    }

    public static List<Vector3d> CreateCubeWireframe(double x, double y, double z, double size, int segments)
    {
        
        var offset = size / 2;
        
        var points = new List<Vector3d>()
        {
            new(x - offset, y - offset, z - offset),
            new(x + offset, y - offset, z - offset),
            new(x + offset, y - offset, z + offset),
            new(x - offset, y - offset, z + offset),
            new(x - offset, y + offset, z - offset),
            new(x + offset, y + offset, z - offset),
            new(x + offset, y + offset, z + offset),
            new(x - offset, y + offset, z + offset),
        };
        
        var segmentLength = size / (segments + 1);
        
        for (var i = 1; i <= segments; i++)
        {
            var length = segmentLength * i;
            
            points.Add(new Vector3d(x - offset + length, y - offset, z - offset));
            points.Add(new Vector3d(x - offset, y - offset + length, z - offset));
            points.Add(new Vector3d(x - offset, y - offset, z - offset + length));
            
            points.Add(new Vector3d(x + offset - length, y + offset, z + offset));
            points.Add(new Vector3d(x + offset, y + offset - length, z + offset));
            points.Add(new Vector3d(x + offset, y + offset, z + offset - length));
            
            points.Add(new Vector3d(x - offset + length, y - offset, z + offset));
            points.Add(new Vector3d(x - offset, y - offset + length, z + offset));
            
            points.Add(new Vector3d(x - offset + length, y + offset, z - offset));
            points.Add(new Vector3d(x - offset, y + offset, z - offset + length));
            
            points.Add(new Vector3d(x + offset, y - offset + length, z - offset));
            points.Add(new Vector3d(x + offset, y - offset, z - offset + length));
        }
    
        return points;
    }
}