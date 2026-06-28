using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source fileSource = new FileCreateSource(outputPath, false);

            // BMP options with the bound source
            BmpOptions bmpOptions = new BmpOptions { Source = fileSource };

            int width = 800;
            int height = 600;
            int lineCount = 100;

            // Create the canvas image
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics and clear background to white
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Random rnd = new Random();

                for (int i = 0; i < lineCount; i++)
                {
                    // Random start and end points
                    int x1 = rnd.Next(width);
                    int y1 = rnd.Next(height);
                    int x2 = rnd.Next(width);
                    int y2 = rnd.Next(height);

                    // Random color
                    Color randomColor = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    Pen pen = new Pen(randomColor, 1);

                    // Draw the line
                    graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                }

                // Save the bound image
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
 * 1. When a developer needs to generate a BMP placeholder image with a white background and random colored lines for testing image rendering pipelines in a C# application.
 * 2. When creating a simple visual captcha or pattern image in a .NET web project using Aspose.Imaging’s RasterImage and Graphics classes to deter automated bots.
 * 3. When producing a quick diagnostic chart that visualizes random line distributions to benchmark the performance of drawing operations on a BMP canvas.
 * 4. When generating background textures for games or UI prototypes where a BMP file with random line art is required without relying on external design tools.
 * 5. When automating the creation of sample BMP files for documentation or unit tests that need consistent dimensions, a white background, and random color variations.
 */