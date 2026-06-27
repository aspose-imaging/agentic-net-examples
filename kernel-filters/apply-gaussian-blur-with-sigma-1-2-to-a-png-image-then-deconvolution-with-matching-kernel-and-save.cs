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
            string inputPath = "input\\sample.png";
            string outputPath = "output\\result.png";

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
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 1.2
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 1.2));

                // Apply deconvolution (Gauss-Wiener) with matching kernel
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
 * 1. When a developer needs to reduce noise in a PNG screenshot by applying a Gaussian blur with sigma 1.2 and then restore details using a matching Gauss‑Wiener deconvolution before saving the result.
 * 2. When an image‑processing pipeline requires preprocessing of scanned PNG documents to smooth edges with a 5‑pixel Gaussian kernel and then sharpen them with deconvolution to improve OCR accuracy.
 * 3. When a web application must automatically enhance user‑uploaded PNG avatars by blurring background artifacts and then de‑blurring the foreground using matching filter parameters.
 * 4. When a scientific visualization tool needs to simulate camera blur on PNG plots and subsequently reverse the effect with a Gauss‑Wiener filter to compare original and processed data.
 * 5. When a batch job processes PNG product photos, applying a consistent Gaussian blur for aesthetic consistency and then applying deconvolution to retain image sharpness before storing the final files.
 */