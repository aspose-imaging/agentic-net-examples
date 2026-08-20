// HOW-TO: Apply Gaussian Blur to Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input PSD files and corresponding sigma values
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input\image1.psd",
                @"C:\Images\Input\image2.psd",
                @"C:\Images\Input\image3.psd"
            };

            double[] sigmaValues = new double[] { 2.0, 4.5, 6.0 };

            // Ensure the arrays have the same length
            int count = Math.Min(inputPaths.Length, sigmaValues.Length);

            for (int i = 0; i < count; i++)
            {
                string inputPath = inputPaths[i];
                double sigma = sigmaValues[i];

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
                    RasterImage rasterImage = image as RasterImage;
                    if (rasterImage == null)
                    {
                        Console.Error.WriteLine($"Unable to process non-raster image: {inputPath}");
                        continue;
                    }

                    // Apply Gaussian blur with radius 5 and the specified sigma
                    int radius = 5;
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(radius, sigma));

                    // Prepare output PNG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_blurred.png";
                    string outputPath = Path.Combine(@"C:\Images\Output", outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG using default options
                    rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to batch‑process Photoshop PSD layers by applying a custom Gaussian blur to each file before publishing them as web‑ready PNGs.
 * 2. When an automated pipeline must soften product mockups with different blur intensities (sigma values) and output PNG thumbnails for a catalog.
 * 3. When you want to prepare PSD assets for machine‑learning training by reducing detail with varying blur levels and saving them in a lossless format.
 * 4. When a desktop application requires converting multiple PSD designs into blurred PNG previews with specific sigma settings for UI display.
 * 5. When a server‑side service generates blurred background images from PSD sources, using Aspose.Imaging to apply per‑image sigma values and store the results as PNG files.
 */
