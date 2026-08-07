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
        // Hardcoded output path
        string outputPath = @"C:\temp\styled_path.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                path.AddFigure(figure);

                // Create a custom pen with dash style
                Pen pen = new Pen(Color.Blue, 5f);
                pen.DashStyle = DashStyle.Dash; // Dashed line
                // Optional custom dash pattern:
                // pen.DashPattern = new float[] { 10f, 5f };

                // Draw the path using the custom pen
                graphics.DrawPath(pen, path);

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When generating printable PDF reports that need a highlighted dashed border around charts, a developer can use this code to create a PNG with a blue dashed rectangle that can be embedded in the document.
 * 2. When building a web application that displays thumbnail previews of uploaded images with a stylized outline to indicate selection, this snippet can draw a dashed border around the thumbnail and save it as a PNG.
 * 3. When creating automated UI test screenshots that require a visual cue around a specific control area, developers can employ the custom Pen and Graphics.DrawPath to overlay a dashed rectangle on the captured image.
 * 4. When producing map tiles where certain zones must be marked with a distinct dashed perimeter, the code can generate 500×500 PNG tiles with a blue dashed outline for those zones.
 * 5. When designing a desktop tool that annotates scanned documents with non‑intrusive dashed frames, this example shows how to draw and save the annotation directly to a PNG file using Aspose.Imaging for .NET.
 */