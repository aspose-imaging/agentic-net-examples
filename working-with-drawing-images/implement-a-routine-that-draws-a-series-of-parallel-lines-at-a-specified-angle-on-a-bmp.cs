using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Parameters for parallel lines
                double angleDegrees = 45.0;          // Desired angle
                double spacing = 20.0;               // Space between lines (pixels)
                int lineCount = 20;                  // Number of lines on each side of center
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);

                // Precompute trigonometric values
                double angleRad = angleDegrees * Math.PI / 180.0;
                double dirX = Math.Cos(angleRad);
                double dirY = Math.Sin(angleRad);
                double perpX = -dirY; // Perpendicular direction
                double perpY = dirX;

                // Center of the image
                double cx = image.Width / 2.0;
                double cy = image.Height / 2.0;

                // Length sufficient to cover the whole canvas
                double length = Math.Sqrt(image.Width * image.Width + image.Height * image.Height);

                for (int i = -lineCount; i <= lineCount; i++)
                {
                    double offset = i * spacing;

                    // Compute start and end points for each line
                    double startX = cx + perpX * offset - dirX * length;
                    double startY = cy + perpY * offset - dirY * length;
                    double endX   = cx + perpX * offset + dirX * length;
                    double endY   = cy + perpY * offset + dirY * length;

                    Aspose.Imaging.Point p1 = new Aspose.Imaging.Point((int)Math.Round(startX), (int)Math.Round(startY));
                    Aspose.Imaging.Point p2 = new Aspose.Imaging.Point((int)Math.Round(endX),   (int)Math.Round(endY));

                    graphics.DrawLine(pen, p1, p2);
                }

                // Save the modified image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to overlay a grid of diagonal hatch lines on a BMP blueprint for visual emphasis using Aspose.Imaging for .NET.
 * 2. When a developer wants to generate a watermark pattern of evenly spaced parallel lines at a custom angle on a BMP image for document security.
 * 3. When a developer must create a background texture of slanted stripes for a game sprite sheet stored as BMP using C# graphics drawing.
 * 4. When a developer is required to simulate road lane markings by drawing parallel lines at a specified angle on a BMP map.
 * 5. When a developer needs to produce a printable BMP template with angled guide lines for aligning scanned forms in an imaging workflow.
 */