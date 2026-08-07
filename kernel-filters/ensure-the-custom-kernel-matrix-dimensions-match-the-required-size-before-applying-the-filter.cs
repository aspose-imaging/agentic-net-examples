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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom convolution kernel (3x3 sharpen example)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Validate kernel dimensions: must be square and odd-sized
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows != cols || rows % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be square with odd dimensions.");
                return;
            }

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply the custom convolution filter to the entire image
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to sharpen a PNG image by applying a custom 3x3 convolution kernel before uploading it to a web gallery.
 * 2. When an automated batch job must validate that a user‑provided kernel is square and odd‑sized before filtering JPEG files to avoid runtime errors.
 * 3. When a desktop application wants to ensure the output directory exists and then save the filtered image as PNG after applying a custom convolution filter to improve OCR accuracy.
 * 4. When a C# service processes scanned documents, loads them as RasterImage, applies a sharpen filter to enhance edges, and writes the result to a specified folder for downstream processing.
 * 5. When a developer integrates Aspose.Imaging into a CI pipeline to test that custom kernel dimensions are checked and the convolution filter correctly modifies the image bounds for PNG assets.
 */