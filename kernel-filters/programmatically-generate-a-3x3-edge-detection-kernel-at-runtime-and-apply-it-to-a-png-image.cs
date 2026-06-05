using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 edge detection kernel
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
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
 * 1. When a developer needs to automatically highlight object boundaries in user‑uploaded PNG photos for a web‑based image editor, they can generate a 3x3 edge detection kernel at runtime and apply it using Aspose.Imaging.
 * 2. When an automated quality‑control system must detect defects or scratches on scanned PNG documents, the code can create a custom convolution filter to emphasize edges before analysis.
 * 3. When a mobile app generates stylized thumbnails of PNG assets and wants to add a crisp outline effect without storing pre‑defined kernels, it can compute the edge detection matrix on the fly and filter each image.
 * 4. When a batch‑processing script processes a folder of PNG screenshots to extract UI element contours for machine‑learning training data, the runtime kernel generation simplifies configuration across different image sets.
 * 5. When a developer builds a C# console utility that converts raw PNG images into edge‑enhanced versions for scientific visualization, the code provides a straightforward way to apply a 3x3 edge detection filter programmatically.
 */