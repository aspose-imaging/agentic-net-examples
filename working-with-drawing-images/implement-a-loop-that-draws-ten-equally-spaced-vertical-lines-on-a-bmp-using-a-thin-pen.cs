// HOW-TO: Draw Ten Evenly Spaced Vertical Lines on BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up BMP options
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            int width = 200;
            int height = 200;
            int lineCount = 10;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var pen = new Pen(Color.Black, 1);

                for (int i = 1; i <= lineCount; i++)
                {
                    float x = (float)i * width / (lineCount + 1);
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                image.Save(outputPath);
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
 * 1. When you need to generate a simple grid or ruler overlay on a BMP image for a reporting UI.
 * 2. When creating test patterns to verify image rendering or printer alignment using Aspose.Imaging in C#.
 * 3. When programmatically adding guide lines to a bitmap before exporting it for CAD or design documentation.
 * 4. When producing a background with evenly spaced vertical separators for a chart or dashboard generated on the server.
 * 5. When automating the creation of placeholder graphics with consistent line spacing for unit tests or mockups.
 */
