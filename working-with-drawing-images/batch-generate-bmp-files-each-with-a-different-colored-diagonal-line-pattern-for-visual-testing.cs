using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory for generated BMP files
            string outputDir = @"C:\Temp\DiagonalLines";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Define colors for diagonal lines
            List<Color> colors = new List<Color>
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Magenta,
                Color.Cyan,
                Color.Orange,
                Color.Purple
            };

            int width = 200;
            int height = 200;
            int lineThickness = 5;

            for (int i = 0; i < colors.Count; i++)
            {
                // Construct output file path
                string outputPath = Path.Combine(outputDir, $"diag_{i + 1}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up BMP options with bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create a raster image canvas bound to the output file
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    // Draw a diagonal line using the specified color
                    Graphics graphics = new Graphics(canvas);
                    Pen pen = new Pen(colors[i], lineThickness);
                    graphics.DrawLine(pen, new Point(0, 0), new Point(canvas.Width - 1, canvas.Height - 1));

                    // Save the bound image
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
 * 1. When a developer needs to generate a set of BMP test images with colored diagonal lines to verify that a downstream image‑processing pipeline correctly reads 24‑bit BMP files created with Aspose.Imaging for .NET.
 * 2. When a QA engineer wants to batch‑create sample bitmap assets for visual regression testing of UI components that render diagonal patterns in different colors.
 * 3. When a software team is building a documentation generator that includes example BMP files showing how pen thickness and color affect line drawing in C# using Aspose.Imaging.
 * 4. When an automation script must produce placeholder graphics for a game’s level editor, each BMP containing a unique colored diagonal line to represent different terrain types.
 * 5. When a developer is testing file‑system permissions and folder creation logic by programmatically writing multiple BMP files to a temporary directory using FileCreateSource and RasterImage.
 */