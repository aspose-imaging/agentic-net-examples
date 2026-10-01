// HOW-TO: Batch Convert BMP to SVG with Median Filter and Resize in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                    raster.Resize(300, 300);

                    SvgOptions options = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = raster.Width,
                            PageHeight = raster.Height
                        }
                    };

                    raster.Save(outputPath, options);
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
 * 1. When you need to clean up noisy BMP scans, reduce their size, and store them as scalable SVG files for web display.
 * 2. When a legacy application outputs BMP icons that must be batch‑converted to lightweight SVG vectors while applying a median filter to remove speckles.
 * 3. When preparing a large set of BMP screenshots for inclusion in a responsive UI, you can resize them to 300 × 300 and convert them to SVG for resolution‑independent rendering.
 * 4. When automating the migration of archival BMP graphics to a modern format, applying a median filter ensures smoother edges before vectorization.
 * 5. When building a C# image‑processing pipeline that processes multiple BMP files, applies noise reduction, resizes them uniformly, and outputs SVG for further editing in vector tools.
 */
