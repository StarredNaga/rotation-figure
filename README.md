# rotation-figure

Small C# project that draws rotating 3D wireframes in the terminal using
ASCII characters. Built it to learn how a basic 3D pipeline works:
generate points → rotate → project to 2D → draw.

![demo](demo.gif)

## What it does

Draws three shapes, spinning around all three axes (you may add yours):

- circle (flat ring)
- sphere (point cloud)
- cube wireframe

## Running it

Needs .NET 10. On an older SDK, change `<TargetFramework>` in the `.csproj`
to whatever you have — `net8.0` works fine, nothing here is version-specific.

```bash
git clone https://github.com/yourname/rotation-figure.git
cd ascii-3d-shapes
dotnet run
```

`Ctrl+C` to stop.

The shape is hardcoded in `Program.cs` and defaults to a circle. To try
another one, swap the line:

```csharp
var points = FigureEngine.CreateSphere(0, 0, 0, 20, 15, 30);
// or
var points = FigureEngine.CreateCubeWireframe(0, 0, 0, 20, 3);
```

## How it's structured

- `FigureEngine` — generates points for shapes
- `MathEngine` — rotates a point and projects it to 2D
- `RenderEngine` — char buffer, writes it to the console
- `Program` — the main loop

`Vector2d` and `Vector3d` are plain structs.

## License

MIT