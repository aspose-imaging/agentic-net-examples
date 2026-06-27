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
            // Hardcoded input PSD files
            string[] inputPaths = {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd",
                @"C:\Images\image3.psd"
            };

            // Corresponding sigma values for Gaussian blur
            double[] sigmaValues = { 2.0, 4.5, 3.2 };

            // Ensure arrays have the same length
            int count = Math.Min(inputPaths.Length, sigmaValues.Length);

            for (int i = 0; i < count; i++)
            {
                string inputPath = inputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage raster = (RasterImage)image;

                    // Apply Gaussian blur with fixed radius and custom sigma
                    int radius = 5; // radius can be any positive integer
                    double sigma = sigmaValues[i];
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(radius, sigma));

                    // Prepare output PNG path
                    string outputDirectory = @"C:\Output";
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

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
 * 1. When a developer needs to batch‑process Photoshop PSD files to create soft‑focus thumbnails for a web gallery, applying different Gaussian blur sigma values per image and exporting them as PNG.
 * 2. When an e‑commerce platform wants to generate blurred background images for product overlays, reading PSD assets, applying custom sigma values for visual consistency, and saving lightweight PNGs.
 * 3. When a marketing team requires automated creation of promotional banners with varying blur intensities for A/B testing, using C# to load PSD layers, apply Gaussian blur, and output PNG assets.
 * 4. When a digital asset management system must convert high‑resolution PSD designs into preview PNGs with controlled blur to protect proprietary details while still showing composition.
 * 5. When a game developer needs to pre‑process PSD textures into blurred PNG sprites with per‑texture sigma settings for depth‑of‑field effects in the UI.
 */