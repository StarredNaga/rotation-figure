namespace RotationFigure;

public class RenderEngine
{
    private int _width;
    
    private int _height;
    
    private int _bufferSize;

    private char[] _buffer;
    
    private char _emptySymbol;
    private char _drawSymbol;

    public RenderEngine(int width, int height, char drawSymbol = '*', char emptySymbol = ' ')
    {
        _width = width;
        _height = height;
        
        _bufferSize = (_width + 1) * _height;
        
        _buffer = new char[_bufferSize];
        
        _emptySymbol = emptySymbol;
        _drawSymbol = drawSymbol;
    }

    public void ResizeBuffer(int width, int height)
    {
        _width = width;
        _height = height;
        
        _bufferSize = (_width + 1) * _height;
        
        _buffer = new char[_bufferSize];
    }

    public void Render(List<Vector2d> points)
    {
        Array.Fill(_buffer, _emptySymbol);
    
        for (var y = 0; y < _height; y++)
        {
            _buffer[y * (_width + 1) + _width] = '\n';
        }
        
        foreach (var point in points)
        {
            var x = (int)Math.Round(point.X);
            var y = (int)Math.Round(point.Y);
            
            if (x >= 0 && x < _width && y >= 0 && y < _height)
            {
                var bufferIndex = y * (_width + 1) + x;
            
                _buffer[bufferIndex] = _drawSymbol; 
            }
        }
        
        Console.SetCursorPosition(0, 0);

        Console.Write(_buffer, 0, _bufferSize - 1);
    }
}