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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Define Gaussian blur parameters (size must be odd, sigma = 1.2)
                int kernelSize = 5; // example odd size
                double sigma = 1.2;

                // Apply Gaussian blur
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(kernelSize, sigma));

                // Apply Gaussian deconvolution (using GaussWiener filter with same kernel)
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(kernelSize, sigma));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to reduce noise in a PNG screenshot before performing OCR, they can apply a Gaussian blur with sigma 1.2 and then deconvolve to restore sharpness using Aspose.Imaging for .NET.
 * 2. When preparing product photos for an e‑commerce catalog, a C# application can smooth the image with a Gaussian blur and reverse the effect with deconvolution to achieve a balanced look while preserving details.
 * 3. When creating a medical imaging workflow that requires subtle smoothing of PNG scans followed by restoration of fine structures, the code demonstrates how to use Gaussian blur and Gauss‑Wiener deconvolution in Aspose.Imaging.
 * 4. When building an automated batch processor that normalizes the visual quality of PNG assets by applying a controlled blur and then deblurring them, this snippet shows the necessary C# operations.
 * 5. When implementing a custom filter pipeline in a .NET desktop app to simulate lens blur and then correct it for artistic effects, the example illustrates how to use GaussianBlurFilterOptions and GaussWienerFilterOptions on a RasterImage.
 */