using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 1.2
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 1.2));

                // Apply Gaussian deconvolution (Gauss-Wiener) with matching kernel
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussWienerFilterOptions(5, 1.2));

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
 * 1. When a developer needs to pre‑process a PNG image to smooth out high‑frequency noise before applying computer‑vision algorithms, they can use Aspose.Imaging in C# to apply a Gaussian blur with sigma 1.2 and then restore edge detail with Gauss‑Wiener deconvolution, saving the cleaned image.
 * 2. When building a .NET application that automatically improves the visual quality of scanned PNG documents for archival, the code can blur the image to suppress scanning artifacts and then deconvolve with a matching kernel to retain sharpness, using the RasterImage.Filter method.
 * 3. When creating a batch‑processing tool that prepares PNG assets for web delivery by reducing speckle noise while preserving fine details, a developer can invoke the GaussianBlurFilterOptions and GaussWienerFilterOptions in Aspose.Imaging to achieve the effect in a single C# workflow.
 * 4. When integrating image enhancement into a medical‑imaging viewer that loads PNG scans, the developer can apply a sigma 1.2 Gaussian blur to smooth sensor noise and then perform Gauss‑Wiener deconvolution to recover diagnostic details before saving the result.
 * 5. When implementing a C# service that receives user‑uploaded PNG pictures and needs to normalize their appearance by removing grain and then sharpening the image, the provided code demonstrates how to chain Gaussian blur and deconvolution filters with Aspose.Imaging and write the output to a new file.
 */