using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = "output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create source and BMP options
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);

                // Clear canvas to teal
                graphics.Clear(Color.Teal);

                // Draw white ellipse centered in the canvas
                Pen pen = new Pen(Color.White, 2);
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 300));

                // Save the image (bound to the source)
                canvas.Save();
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
 * 1. When a developer needs to generate a simple BMP placeholder image with a teal background and a centered white ellipse for UI mockups or testing image loading pipelines.
 * 2. When an application must programmatically create a bitmap logo or badge in C# using Aspose.Imaging, clearing the canvas to a specific color and drawing a vector ellipse for branding.
 * 3. When automated test suites require consistent raster images in BMP format to verify rendering performance, using the code to produce a known teal‑background ellipse image.
 * 4. When a reporting tool needs to embed a dynamically generated BMP chart element, such as a white ellipse on a teal background, without relying on external image files.
 * 5. When a game or simulation engine needs to create texture assets on the fly in .NET, employing Aspose.Imaging to draw basic shapes like an ellipse onto a BMP canvas for prototyping.
 */