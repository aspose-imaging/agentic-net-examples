using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // 4x4 averaging kernel (sum equals 1)
                double[,] kernel = new double[4, 4]
                {
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 }
                };

                // Create convolution filter options (factor 1, bias 0)
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
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
 * 1. When a developer needs to smooth a PNG image by applying a custom 4x4 averaging convolution filter to reduce noise before further analysis.
 * 2. When a developer wants to preserve overall brightness while blurring a PNG by using a kernel whose elements sum to one, preventing unintended exposure changes.
 * 3. When a developer must preprocess scanned PNG documents with a uniform blur to improve OCR accuracy using Aspose.Imaging’s ConvolutionFilterOptions.
 * 4. When a developer is building an automated C# image pipeline that loads PNG files, applies a custom kernel for edge softening, and saves the processed image to a specific output folder.
 * 5. When a developer needs to demonstrate file existence validation, output directory creation, and the application of a custom convolution filter to a raster image in a .NET console application.
 */