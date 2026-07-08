using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_processed.png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image and process
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Automatic normalization (histogram)
                    raster.NormalizeHistogram();

                    // Define a custom kernel with sum 0.9
                    double[,] kernel = new double[,]
                    {
                        { 0.1, 0.2 },
                        { 0.2, 0.4 }
                    };

                    // Create convolution filter options with the custom kernel
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                    // Apply the custom filter to the entire image
                    raster.Filter(raster.Bounds, filterOptions);

                    // Save the processed image as PNG
                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
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
 * 1. When a developer needs to improve the visual consistency of a large set of product photos stored as PNGs before uploading them to an e‑commerce site, they can batch normalize the histograms and apply a custom sharpening kernel with a sum of 0.9.
 * 2. When preparing medical imaging scans in PNG format for automated analysis, a developer can use this code to automatically balance contrast via histogram normalization and then apply a subtle edge‑enhancement filter to highlight structures without over‑amplifying noise.
 * 3. When generating game assets, a developer may batch process sprite sheets to ensure each PNG has a uniform brightness level and a custom blur kernel that preserves detail while keeping the overall intensity at 0.9.
 * 4. When archiving scanned documents as PNG files, a developer can run this routine to normalize the grayscale histogram and apply a lightweight smoothing kernel so the pages appear clear and evenly lit in a digital library.
 * 5. When creating a batch of promotional banners in PNG format, a developer can automatically normalize colors across all images and apply a custom kernel to slightly increase contrast, ensuring a consistent look across different screen resolutions.
 */