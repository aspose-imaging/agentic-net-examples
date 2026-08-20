// HOW-TO: Apply Horizontal Sobel Edge Detection to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\sample_sobel.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image as RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define horizontal Sobel kernel (3x3)
                double[,] sobelKernel = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                // Apply convolution filter with factor 1.0 and bias 0
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(sobelKernel, 1.0, 0));

                // Save result as PNG
                PngOptions pngOptions = new PngOptions();
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
 * 1. When you need to highlight horizontal edges in a scanned document PNG before OCR processing.
 * 2. When preparing PNG screenshots for feature extraction in a computer‑vision pipeline that requires Sobel edge maps.
 * 3. When creating visual diagnostics for manufacturing line images by emphasizing horizontal lines using a Sobel filter.
 * 4. When converting raw PNG photos into edge‑detected versions for artistic effects in a .NET desktop application.
 * 5. When preprocessing PNG images for machine‑learning models that benefit from gradient information along the X‑axis.
 */
