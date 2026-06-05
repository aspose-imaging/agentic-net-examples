using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Create a 7x7 blur box kernel
                double[,] kernel = ConvolutionFilter.GetBlurBox(7);

                // Prepare filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the blur filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as BMP
                raster.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to reduce noise in scanned BMP documents by applying a stronger 7x7 blur box filter instead of the default 3x3 kernel.
 * 2. When creating a preprocessing step in a C# image‑processing pipeline that smooths BMP textures before edge detection or OCR.
 * 3. When building a desktop application that lets users import legacy BMP graphics and automatically soften harsh pixelation with a larger convolution kernel.
 * 4. When generating test images for performance benchmarking of BMP compression algorithms, requiring a consistent 7x7 blur to simulate real‑world smoothing.
 * 5. When integrating Aspose.Imaging into a batch job that processes a folder of BMP files, applying a 7x7 blur box to improve visual quality for web publishing.
 */