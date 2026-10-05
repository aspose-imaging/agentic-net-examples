// HOW-TO: Batch Resize Raster Images to 1024x1024 and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image img = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)img;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.Resize(1024, 1024);
                    raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = 1024,
                            PageHeight = 1024,
                            BackgroundColor = Aspose.Imaging.Color.White
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
 * 1. When you need to prepare a large set of photos for a web‑based vector graphics viewer by resizing them uniformly and converting them to SVG.
 * 2. When you want to reduce noise in scanned documents before vectorizing them, applying a median filter to each raster file in a folder.
 * 3. When an e‑commerce platform requires product images to be standardized to 1024 × 1024 pixels and delivered as scalable SVG files for responsive design.
 * 4. When automating the migration of legacy bitmap assets to SVG for a mobile app, ensuring each image is resized and denoised in a single batch process.
 * 5. When creating a preprocessing pipeline for machine‑learning training data that expects clean, uniformly sized SVG inputs derived from various raster formats.
 */
