// HOW-TO: How To Translate And Rotate SVG Onto PNG Canvas In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector graphic (SVG) as a raster image
            using (RasterImage vectorImage = (RasterImage)Image.Load(inputPath))
            {
                // Create a PNG canvas
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image canvas = Image.Create(pngOptions, 800, 600))
                {
                    // Initialize graphics for the canvas
                    Graphics graphics = new Graphics(canvas);

                    // Apply translation and rotation transforms
                    graphics.TranslateTransform(200, 150);
                    graphics.RotateTransform(45);

                    // Draw the vector image at the origin (transforms will position it)
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    // Save the canvas (output file is already bound to the source)
                    canvas.Save();
                }
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
 * 1. When you need to place an SVG logo at a specific position and angle on a larger PNG report generated in C#.
 * 2. When creating dynamic thumbnails that require rotating and offsetting vector icons before saving them as PNG files.
 * 3. When building a map overlay where SVG symbols must be shifted and turned to align with geographic coordinates in a .NET application.
 * 4. When automating the generation of printable flyers that combine multiple SVG illustrations positioned precisely on a fixed-size PNG canvas.
 * 5. When developing a game UI that composites rotated SVG assets onto a background PNG texture at runtime using Aspose.Imaging.
 */
