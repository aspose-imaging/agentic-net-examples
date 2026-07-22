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
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.png";
            string outputPath = "C:\\temp\\output_sobel.png";

            // Verify input file exists
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
                // Cast to RasterImage to access pixel data and filtering
                RasterImage raster = (RasterImage)image;

                // Define the horizontal Sobel kernel
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply the convolution filter over the entire image bounds
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(sobelKernel));

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to detect horizontal edges in a PNG photograph to highlight road lane markings for a traffic‑analysis application.
 * 2. When a C# program must preprocess scanned documents by applying a Sobel filter to emphasize text baselines before OCR processing.
 * 3. When an image‑processing pipeline requires extracting horizontal gradients from satellite PNG tiles to identify river boundaries.
 * 4. When a developer wants to create a visual effect that outlines the top and bottom edges of objects in a game sprite sheet using convolution.
 * 5. When a quality‑control tool needs to compare the edge intensity of manufactured product images by generating Sobel‑filtered PNGs for defect detection.
 */