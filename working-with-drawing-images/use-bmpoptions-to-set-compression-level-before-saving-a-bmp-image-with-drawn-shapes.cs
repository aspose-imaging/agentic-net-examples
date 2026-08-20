// HOW-TO: Set BMP Compression Level and Draw Shapes in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source for the BMP image
            Source source = new FileCreateSource(outputPath, false);

            // Configure BMP options with desired compression
            BmpOptions bmpOptions = new BmpOptions()
            {
                Source = source,
                Compression = BitmapCompression.Rgb // No compression (RGB)
            };

            // Create a BMP canvas of size 400x300
            using (Image canvas = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Fill a rectangle with a solid brush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.LightBlue;
                    brush.Opacity = 100;
                    graphics.FillRectangle(brush, new Rectangle(50, 50, 200, 150));
                }

                // Draw rectangle border
                graphics.DrawRectangle(new Pen(Color.DarkBlue, 2), new Rectangle(50, 50, 200, 150));

                // Draw an ellipse inside the rectangle
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(100, 100, 150, 100));

                // Save the bound image (options already contain the output path)
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
 * 1. When you need to generate a BMP image with custom rectangles and ellipses in a .NET app while explicitly setting the compression mode to control file size.
 * 2. When creating graphics for legacy Windows software that requires uncompressed RGB BMP files and you want to automate the drawing process in C#.
 * 3. When producing diagrammatic reports that include colored shapes and you must specify BMP compression settings programmatically using Aspose.Imaging.
 * 4. When exporting server‑side rendered drawings to BMP format to meet compatibility requirements of older systems that expect a specific compression type.
 * 5. When building a batch job that adds visual annotations to BMP files and you need to control the compression level for each output image in C#.
 */
