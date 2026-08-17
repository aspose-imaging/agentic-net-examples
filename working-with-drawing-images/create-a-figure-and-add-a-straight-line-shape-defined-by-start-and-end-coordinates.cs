// HOW-TO: Create BMP Image With Straight Line Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png"; // Not used but kept for rule compliance
        string outputPath = @"c:\temp\line_figure_output.bmp";

        try
        {
            // Input file existence check (rule 2)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule 3)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Define start and end points for the straight line
                PointF startPoint = new PointF(100f, 100f);
                PointF endPoint = new PointF(400f, 300f);

                // Draw the line using a black pen of width 2
                graphics.DrawLine(new Pen(Color.Black, 2), startPoint, endPoint);

                // Save the image (since the source is already bound, just call Save)
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
 * 1. When you need to generate a BMP diagram programmatically and add a custom line for engineering schematics.
 * 2. When creating placeholder graphics for UI testing that require a specific background color and a black line overlay.
 * 3. When automating the production of simple vector‑style illustrations, such as arrows or connectors, in batch image processing pipelines.
 * 4. When exporting chart data as a static image where a trend line must be drawn directly onto a 500×500 canvas.
 * 5. When building a server‑side service that returns a bitmap with dynamically calculated line coordinates for reporting or annotation purposes.
 */
