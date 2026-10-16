// HOW-TO: Rotate a Rectangle 45 Degrees Around Center Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 400;

            var options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                float rectWidth = 200f;
                float rectHeight = 100f;
                float rectX = (width - rectWidth) / 2f;
                float rectY = (height - rectHeight) / 2f;

                var rectShape = new RectangleShape(new RectangleF(rectX, rectY, rectWidth, rectHeight));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                graphics.TranslateTransform(width / 2f, height / 2f);
                graphics.RotateTransform(45f);
                graphics.TranslateTransform(-width / 2f, -height / 2f);

                Pen pen = new Pen(Color.Blue);
                graphics.DrawPath(pen, path);

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PNG image with a rectangle rotated 45 degrees using Graphics.RotateTransform for a web banner.
 * 2. When creating dynamic diagrams in C# where vector shapes must be tilted, such as rotating a rectangle around its center with Aspose.Imaging.
 * 3. When preparing printable assets that require precise 45‑degree rotation of a rectangle before saving as PNG via Aspose.Imaging graphics.
 * 4. When building a custom watermark that is angled across an image by applying RotateTransform to a GraphicsPath in C#.
 * 5. When developing a game UI element that needs a rotated rectangular button rendered on the fly using Aspose.Imaging.
 */
