// HOW-TO: Batch Invert BMP Images and Save as SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // List of BMP files to process (hardcoded)
            string[] bmpFiles = new[]
            {
                "image1.bmp",
                "image2.bmp",
                "image3.bmp"
            };

            foreach (string fileName in bmpFiles)
            {
                string inputPath = Path.Combine(inputFolder, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                string outputPath = Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".svg"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Invert colors pixel by pixel
                    var raster = image as RasterImage;
                    if (raster != null)
                    {
                        for (int y = 0; y < raster.Height; y++)
                        {
                            for (int x = 0; x < raster.Width; x++)
                            {
                                var color = raster.GetPixel(x, y);
                                var inverted = Aspose.Imaging.Color.FromArgb(
                                    color.A,
                                    255 - color.R,
                                    255 - color.G,
                                    255 - color.B);
                                raster.SetPixel(x, y, inverted);
                            }
                        }
                    }

                    // Save as SVG using default options
                    var svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically convert a set of legacy BMP graphics to scalable SVG files with inverted colors for a web‑based UI.
 * 2. When a desktop application must preprocess scanned BMP icons by applying a negative filter before embedding them in vector‑based reports.
 * 3. When a game asset pipeline requires batch generation of SVG silhouettes from BMP sprites to create outline effects.
 * 4. When an automated build script has to transform multiple BMP screenshots into inverted SVG diagrams for documentation purposes.
 * 5. When a data‑visualization tool needs to read BMP charts, invert their colors for dark‑mode themes, and export them as SVG for resolution‑independent rendering.
 */
