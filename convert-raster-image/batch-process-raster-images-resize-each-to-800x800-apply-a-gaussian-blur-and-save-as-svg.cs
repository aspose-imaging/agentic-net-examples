// HOW-TO: Batch Resize Images to 800x800 Apply Gaussian Blur and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string file in files)
            {
                string inputPath = file;
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".svg");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.Resize(800, 800, ResizeType.NearestNeighbourResample);

                    var blurOptions = new GaussianBlurFilterOptions { Radius = 5 };
                    raster.Filter(raster.Bounds, blurOptions);

                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = raster.Width,
                            PageHeight = raster.Height
                        }
                    };

                    raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate web‑ready SVG thumbnails from a folder of photos, resizing them to a uniform 800×800 size and adding a soft blur for a consistent look.
 * 2. When an e‑commerce platform requires product images to be resized, blurred for background effect, and stored as scalable SVG files for responsive design.
 * 3. When a digital asset management system must batch‑process legacy raster files, apply a Gaussian blur, and convert them to vector‑compatible SVG format for easier scaling.
 * 4. When creating a gallery of stylized icons where each original bitmap must be resized, softened, and saved as SVG to maintain quality across different screen resolutions.
 * 5. When automating the preparation of marketing assets, converting a collection of JPEG or PNG files into 800×800 blurred SVGs using C# to streamline the design workflow.
 */
