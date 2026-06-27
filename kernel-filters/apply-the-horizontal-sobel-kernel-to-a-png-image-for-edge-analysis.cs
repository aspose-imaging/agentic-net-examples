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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output_sobel.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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

                // Create convolution filter options with the Sobel kernel
                var filterOptions = new ConvolutionFilterOptions(sobelKernel);

                // Apply the filter to the entire image bounds
                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When a developer needs to detect horizontal edges in scanned PNG receipts to improve OCR accuracy, they can use the Aspose.Imaging convolution filter with a Sobel kernel as shown.
 * 2. When building a medical imaging application that highlights bone structures in PNG X‑ray images, applying the horizontal Sobel convolution filter emphasizes linear features for analysis.
 * 3. When creating a quality‑control system for printed circuit boards, applying the Sobel filter to PNG photographs of the board reveals missing or misaligned traces by extracting horizontal edges.
 * 4. When developing a computer‑vision preprocessing step for autonomous drones, the code can generate a horizontal edge map from PNG terrain snapshots using the Sobel convolution filter to aid navigation.
 * 5. When generating artistic edge‑enhanced thumbnails of PNG photos for a web gallery, the Sobel filter provides a fast way to accentuate outlines while preserving the original image format.
 */