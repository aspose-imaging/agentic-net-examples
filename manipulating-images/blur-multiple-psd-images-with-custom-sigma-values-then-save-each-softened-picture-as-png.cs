using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Define PSD input files and their custom sigma values
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
                    return;
                }

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Ensure the image can be processed as a raster image
                    var raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image type (not raster): {inputPath}");
                        continue;
                    }

                    // Apply Gaussian blur with a fixed radius and custom sigma
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, item.Sigma));

                    // Determine output PNG path
                    string outputPath = Path.ChangeExtension(inputPath, ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the blurred image as PNG
                    raster.Save(outputPath);
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
 * 1. When a web‑based portfolio needs to generate soft‑focus preview thumbnails from high‑resolution PSD files, a developer can use this code to apply different Gaussian blur strengths and output PNG previews.
 * 2. When an e‑commerce platform wants to create blurred background images for product detail pages from original PSD assets, the code lets the developer batch‑process each file with a custom sigma and save lightweight PNGs.
 * 3. When a marketing automation tool must prepare stylized social‑media graphics by applying varying blur levels to PSD source files before publishing, the developer can employ this routine to automate the conversion to PNG.
 * 4. When a digital asset management system requires generating low‑resolution, privacy‑preserving PNG copies of confidential PSD artwork, the code provides a way to blur each image with a specific sigma per file.
 * 5. When a game development pipeline needs to pre‑process layered PSD textures into blurred PNG sprites with different intensities for depth‑of‑field effects, a developer can run this script to batch‑apply Gaussian blur and export the results.
 */