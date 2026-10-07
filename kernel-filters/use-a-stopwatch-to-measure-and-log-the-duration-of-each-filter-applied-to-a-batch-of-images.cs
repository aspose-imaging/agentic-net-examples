// HOW-TO: Measure Execution Time of Gaussian Blur Filter on Multiple Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputImages";
            string outputDir = "OutputImages";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_filtered.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Skipping non-raster image: {inputPath}");
                        continue;
                    }

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                    raster.Filter(raster.Bounds, filterOptions);

                    var jpegOptions = new JpegOptions { Quality = 90 };
                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to benchmark how long a Gaussian blur filter takes on a batch of JPEG files to optimize image‑processing performance.
 * 2. When you want to log the processing time for each image in a batch to generate detailed performance reports for a C# imaging pipeline.
 * 3. When you are comparing different filter parameters or algorithms and require precise timing data to select the most efficient option.
 * 4. When you must ensure that image‑filtering operations meet service‑level agreements in a server‑side C# application.
 * 5. When you are troubleshooting slow image conversions and need to isolate the time spent on each filter step.
 */
