// HOW-TO: Parallel Apply Emboss3x3 Filter to Multiple PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + "_emboss.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                    raster.Save(outputPath);
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
 * 1. When you need to quickly add an emboss effect to a large collection of PNG files for a web gallery, you can run the filter in parallel to reduce processing time.
 * 2. When automating a preprocessing step for a machine‑learning pipeline that requires all input PNG images to have a 3×3 emboss texture, this code processes the whole folder concurrently.
 * 3. When preparing product photos for an e‑commerce site and want to generate embossed thumbnails without blocking the main thread, the Parallel.ForEach loop handles each image independently.
 * 4. When converting a batch of user‑uploaded PNG assets on a server and applying a visual style filter before storage, the Aspose.Imaging ConvolutionFilter.Emboss3x3 can be applied in parallel for scalability.
 * 5. When building a desktop utility that applies the same image filter to dozens of PNG screenshots, using this code lets you leverage multiple CPU cores to finish the job faster.
 */
