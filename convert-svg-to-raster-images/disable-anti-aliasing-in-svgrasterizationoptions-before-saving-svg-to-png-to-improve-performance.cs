// HOW-TO: Convert SVG to PNG without Anti‑Aliasing for Faster Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = Path.Combine(inputDirectory, "image.svg");
            string outputPath = Path.Combine(outputDirectory, "image.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate thumbnail PNGs from user‑uploaded SVG icons quickly, disabling anti‑aliasing speeds up the conversion.
 * 2. When a batch‑processing script converts thousands of vector diagrams to raster PNGs for a reporting system, turning off smoothing reduces CPU load.
 * 3. When a mobile backend service creates PNG previews of SVG assets for low‑power devices, disabling anti‑aliasing improves response time.
 * 4. When a CI pipeline validates SVG assets by rendering them as PNGs without extra smoothing, the code ensures consistent, fast output.
 * 5. When an e‑learning platform converts SVG illustrations to PNG for PDF export and wants to avoid unnecessary rendering overhead, setting SmoothingMode to None helps.
 */
