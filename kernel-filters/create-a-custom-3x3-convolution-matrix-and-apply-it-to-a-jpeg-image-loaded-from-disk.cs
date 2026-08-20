// HOW-TO: Apply Custom 3x3 Sharpen Convolution to JPEG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Define a custom 3x3 convolution kernel (sharpen example)
                double[,] kernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 5, -1 },
                    { 0, -1,  0 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Prepare JPEG save options
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the processed image
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to enhance the details of a JPEG photograph by sharpening it programmatically in a C# application.
 * 2. When you want to apply a custom 3x3 convolution matrix to any raster image for edge enhancement using Aspose.Imaging.
 * 3. When you must process batches of JPEG files on a server, applying the same filter before saving them with a specific quality setting.
 * 4. When you are building an image‑editing tool that lets users upload a JPEG, apply a custom filter, and download the processed result.
 * 5. When you need to ensure the output directory exists and automatically create it while applying a convolution filter to a loaded image.
 */
