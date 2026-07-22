using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a custom sharpening kernel with negative coefficients
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  9, -1 },
                    { -1, -1, -1 }
                };

                // Create convolution filter options using the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG with default options
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to enhance the visual clarity of scanned PNG documents before OCR by applying a custom convolution kernel with negative coefficients using Aspose.Imaging in C#.
 * 2. When a developer wants to sharpen product PNG images for an e‑commerce site while preserving lossless quality by using a custom kernel filter in Aspose.Imaging.
 * 3. When a developer must improve edge detail in satellite PNG imagery for GIS analysis by applying a negative‑coefficient sharpening kernel via Aspose.Imaging’s ConvolutionFilterOptions.
 * 4. When a developer needs to restore crisp edges in low‑resolution PNG screenshots for technical documentation using a custom sharpening kernel in C#.
 * 5. When a developer integrates PNG UI assets into a game and requires a custom sharpening filter to make the graphics appear sharper on high‑DPI displays using Aspose.Imaging.
 */