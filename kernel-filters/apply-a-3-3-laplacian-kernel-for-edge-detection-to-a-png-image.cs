// HOW-TO: Apply 3x3 Laplacian Edge Detection to PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

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
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Define a 3×3 Laplacian kernel
                double[,] laplacianKernel = new double[,]
                {
                    { 0, -1,  0 },
                    { -1, 4, -1 },
                    { 0, -1,  0 }
                };

                // Apply the convolution filter with the Laplacian kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(laplacianKernel));

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
 * 1. When you need to highlight edges in a PNG image for computer‑vision preprocessing.
 * 2. When you want to create a sketch‑like outline of a photo for UI thumbnails.
 * 3. When you must detect boundaries in scanned documents before OCR analysis.
 * 4. When you are building a custom filter pipeline and need a fast Laplacian convolution on raster images.
 * 5. When you need to generate edge maps for quality‑control inspection in manufacturing images.
 */
