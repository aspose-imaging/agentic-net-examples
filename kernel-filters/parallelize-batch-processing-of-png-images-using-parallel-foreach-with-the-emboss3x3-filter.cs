// HOW-TO: Apply Emboss Filter to Multiple PNGs in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            Parallel.ForEach(files, file =>
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (RasterImage raster = (RasterImage)Image.Load(file))
                {
                    var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, filterOptions);

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(file));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var saveOptions = new PngOptions();
                    raster.Save(outputPath, saveOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly add a 3x3 emboss effect to a large collection of PNG files for a web gallery.
 * 2. When you want to speed up image preprocessing by processing PNG images concurrently on a multi‑core server.
 * 3. When you are building a batch conversion tool that applies a convolution filter before saving the results as PNGs.
 * 4. When you must ensure each processed image is saved with Aspose.Imaging’s PNG options while preserving the original filename.
 * 5. When you need to automate image enhancement in a CI pipeline that reads PNGs from a folder, applies an emboss filter, and writes the output to another directory.
 */
