// HOW-TO: Batch Resize Raster Images to 1024x1024 and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.Resize(1024, 1024, ResizeType.NearestNeighbourResample);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = 1024,
                            PageHeight = 1024
                        };

                        raster.Save(outputPath, svgOptions);
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
 * 1. When you need to convert a folder of JPEG or PNG photos into uniformly sized 1024 × 1024 SVG files for responsive web graphics.
 * 2. When an e‑commerce platform must generate vector thumbnails from product photos to reduce bandwidth while keeping consistent dimensions.
 * 3. When a desktop application has to preprocess scanned documents by resizing them and exporting each page as an SVG for further vector editing.
 * 4. When a batch job must prepare a large set of raster assets for inclusion in an SVG‑based UI theme, ensuring all images share the same size.
 * 5. When automating the migration of legacy bitmap icons to scalable SVG icons while applying a standard resize to meet design guidelines.
 */
