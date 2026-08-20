// HOW-TO: Apply Gaussian Blur and Deconvolution to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
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
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 (odd) and sigma 1.2
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 1.2));

                // Apply deconvolution (Gauss-Wiener) with matching kernel parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 1.2));

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
 * 1. When you need to reduce noise in a scanned PNG before OCR by blurring and then restoring details with deconvolution.
 * 2. When preparing product photos for a web catalog, you can smooth edges with Gaussian blur and sharpen them back using Gauss‑Wiener deconvolution.
 * 3. When cleaning up medical imaging PNGs that contain grain, applying a blur followed by deconvolution helps improve visual clarity without losing diagnostic information.
 * 4. When creating a batch job that automatically enhances PNG screenshots from UI tests, the code can apply a controlled blur and reverse it to balance contrast.
 * 5. When implementing a custom image preprocessing pipeline in a C# application, you can use Aspose.Imaging to apply Gaussian blur with sigma 1.2 and then deconvolve with a matching kernel before saving the result.
 */
