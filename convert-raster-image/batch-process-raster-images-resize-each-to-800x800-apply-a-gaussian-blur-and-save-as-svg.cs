// HOW-TO: Batch Resize and Blur Raster Images to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
                        continue;
                    }

                    raster.Resize(800, 800, ResizeType.NearestNeighbourResample);

                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                    raster.Filter(raster.Bounds, blurOptions);

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
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
 * 1. When you need to convert a folder of photos into uniformly sized 800×800 SVG graphics with a soft blur for web thumbnails.
 * 2. When generating scalable vector placeholders from raster assets for responsive design while maintaining consistent dimensions.
 * 3. When preparing a batch of product images for an e‑commerce catalog that requires blurred background effects and SVG output for faster loading.
 * 4. When automating the preprocessing of scanned documents to standard size and applying Gaussian smoothing before vectorizing them.
 * 5. When creating a set of icons from bitmap sources that must be resized, blurred, and saved as SVG for use in mobile applications.
 */
