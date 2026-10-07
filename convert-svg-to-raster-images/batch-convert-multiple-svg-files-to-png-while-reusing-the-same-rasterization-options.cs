// HOW-TO: Batch Convert Multiple SVG Files to PNG with Shared Rasterization Options in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White
            };

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    rasterOptions.PageWidth = image.Width;
                    rasterOptions.PageHeight = image.Height;

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to generate PNG thumbnails for a large collection of SVG icons for a web UI.
 * 2. When an automated build process must convert design assets from SVG to PNG for inclusion in a mobile app.
 * 3. When a reporting tool requires raster images instead of vectors and you must batch‑process SVG charts into PNG files.
 * 4. When you want to preserve a consistent background color and size across many SVG‑to‑PNG conversions using Aspose.Imaging in C#.
 * 5. When a migration script has to replace SVG graphics with PNG equivalents while reusing rasterization settings to improve performance.
 */
