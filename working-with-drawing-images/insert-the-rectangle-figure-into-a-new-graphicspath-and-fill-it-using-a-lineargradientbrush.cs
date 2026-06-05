using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source pointing to the output path
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (500x500) using the options
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Define rectangle bounds
                RectangleF rect = new RectangleF(50f, 50f, 400f, 400f);

                // Create a rectangle shape and add it to a figure
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(rect));

                // Create a graphics path and add the figure
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Create a linear gradient brush (blue to red)
                LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Blue, Color.Red, 0f);

                // Fill the rectangle figure using the gradient brush
                graphics.FillPath(brush, path);

                // Save the image (the output path is already defined in the options)
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
 * 1. When a .NET developer must create a 500 × 500 BMP file with a blue‑to‑red gradient‑filled rectangle for a dynamic report header using Aspose.Imaging’s GraphicsPath and LinearGradientBrush.
 * 2. When an application needs to generate a printable badge image where a rectangular background is filled with a smooth color transition, leveraging C# and Aspose.Imaging’s FillPath method.
 * 3. When a software solution requires programmatically drawing a gradient rectangle onto a white canvas to produce custom UI icons in BMP format with Aspose.Imaging.
 * 4. When an automated batch process has to overlay a gradient‑filled rectangle onto images for watermarking or branding, using Aspose.Imaging’s Figure, GraphicsPath, and LinearGradientBrush classes.
 * 5. When a developer is building a graphics‑intensive game asset pipeline that needs to render gradient rectangles into BMP textures directly from C# code with Aspose.Imaging.
 */