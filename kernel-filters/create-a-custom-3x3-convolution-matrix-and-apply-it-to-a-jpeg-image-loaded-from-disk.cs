using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a custom 3x3 convolution kernel (sharpen example)
                double[,] kernel = new double[3, 3]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Create filter options with the custom kernel
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to programmatically sharpen a JPEG photograph in a .NET application using Aspose.Imaging’s custom 3×3 convolution filter.
 * 2. When an e‑commerce platform wants to automatically enhance uploaded product JPEG images by applying a custom kernel to improve visual clarity.
 * 3. When a desktop utility must batch‑process scanned JPEG documents to emphasize edges before OCR, using C# and Aspose.Imaging’s raster filter.
 * 4. When a server‑side service stores user‑generated JPEGs and requires on‑the‑fly image sharpening to reduce blur without relying on external tools.
 * 5. When a scientific imaging application needs to apply a custom convolution matrix to JPEG microscopy images for feature detection within a .NET workflow.
 */