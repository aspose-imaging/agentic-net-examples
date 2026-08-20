// HOW-TO: Apply Vertical Sobel Edge Detection to PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/sample.png";
            string outputPath = "output/vertical_sobel.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Define vertical Sobel 3x3 kernel (detect vertical edges)
                double[,] verticalSobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Create convolution filter options (factor = 1, bias = 0)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    verticalSobelKernel,
                    1.0,
                    0);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the result as PNG
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to highlight vertical edges in a scanned document PNG before OCR processing.
 * 2. When you want to create a stylized outline effect for product photos by applying a Sobel filter in a .NET application.
 * 3. When you must preprocess satellite imagery to detect vertical structures such as roads or building edges using Aspose.Imaging.
 * 4. When you are building a computer‑vision pipeline that requires extracting vertical edge maps from PNG frames in real‑time.
 * 5. When you need to automate batch conversion of PNG assets to emphasize vertical edges for quality‑control inspection.
 */
