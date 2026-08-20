// HOW-TO: Apply Vertical Edge Detection Filter to PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\landscape.png";
            string outputPath = "output\\filtered.png";

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
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Define a vertical edge detection kernel (Sobel operator)
                double[,] verticalKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(verticalKernel);

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to highlight vertical structures such as building edges in a landscape PNG for computer‑vision preprocessing.
 * 2. When you want to create an edge‑enhanced PNG version of a photograph for artistic or printing effects.
 * 3. When you are developing a C# application that automatically applies a Sobel vertical edge filter to user‑uploaded images.
 * 4. When you must preprocess PNG images to emphasize vertical edges before feeding them into a machine‑learning model.
 * 5. When you require a filtered PNG output to improve visual contrast for GIS or mapping visualizations.
 */
