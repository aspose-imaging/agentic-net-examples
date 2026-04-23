using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Define PSD input files and their corresponding sigma values
            var inputs = new[]
            {
                new { Path = @"C:\Images\image1.psd", Sigma = 2.0 },
                new { Path = @"C:\Images\image2.psd", Sigma = 4.5 },
                new { Path = @"C:\Images\image3.psd", Sigma = 1.5 }
            };

            foreach (var item in inputs)
            {
                string inputPath = item.Path;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output PNG path (same folder, same name, .png extension)
                string outputPath = Path.ChangeExtension(inputPath, ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unable to process non‑raster image: {inputPath}");
                        continue;
                    }

                    // Define radius (must be positive odd integer) and sigma for Gaussian blur
                    int radius = 5; // example radius
                    double sigma = item.Sigma;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(radius, sigma));

                    // Save the blurred image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}