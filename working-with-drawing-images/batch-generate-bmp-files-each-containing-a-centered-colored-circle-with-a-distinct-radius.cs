// HOW-TO: Create Multiple BMP Images with Centered Red Circles of Varying Radii in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory and ensure it exists
            string outputDir = @"C:\Temp\Circles";
            Directory.CreateDirectory(outputDir);

            // Canvas size
            int canvasWidth = 200;
            int canvasHeight = 200;
            int centerX = canvasWidth / 2;
            int centerY = canvasHeight / 2;

            // Radii for distinct circles
            int[] radii = new int[] { 20, 40, 60, 80 };

            foreach (int radius in radii)
            {
                // Build output file path
                string outputPath = Path.Combine(outputDir, $"circle_{radius}.bmp");

                // Ensure output directory exists before each save
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with file source
                var source = new FileCreateSource(outputPath, false);
                var bmpOptions = new BmpOptions()
                {
                    BitsPerPixel = 24,
                    Source = source
                };

                // Create image canvas bound to the file
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    var graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Define pen for the circle outline
                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2);

                    // Rectangle that bounds the circle
                    var bounds = new Aspose.Imaging.Rectangle(
                        centerX - radius,
                        centerY - radius,
                        radius * 2,
                        radius * 2);

                    // Draw the centered circle
                    graphics.DrawEllipse(pen, bounds);

                    // Save the bound image
                    image.Save();
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
 * 1. When you need to generate a set of placeholder icons for UI testing, you can programmatically create BMP files with centered circles of different sizes using Aspose.Imaging in C#.
 * 2. When preparing sample data for computer‑vision algorithms that detect circular objects, this code quickly produces BMP images containing red circles with known radii.
 * 3. When automating the creation of printable calibration charts for scanners or cameras, you can batch‑save BMP files with centered circles to ensure consistent dimensions.
 * 4. When building a game asset pipeline that requires simple circular sprites in BMP format, this script generates each radius variant without manual editing.
 * 5. When teaching image‑processing concepts, you can demonstrate drawing primitives and file output by creating a series of BMP images with centered colored circles of varying sizes.
 */
