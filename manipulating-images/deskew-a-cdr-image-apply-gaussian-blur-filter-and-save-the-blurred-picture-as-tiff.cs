using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

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

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Deskew the image (normalize angle)
                raster.NormalizeAngle();

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as TIFF
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
 * 1. When a graphic designer needs to automatically straighten scanned CorelDRAW (CDR) drawings and apply a soft Gaussian blur before archiving them as high‑resolution TIFF files.
 * 2. When a document management system processes uploaded CDR artwork, corrects any skew, adds a Gaussian blur to reduce noise, and stores the result in TIFF for long‑term preservation.
 * 3. When a batch‑processing tool converts legacy CDR illustrations into printable TIFFs, using deskew to align the page and blur to smooth edges for better print quality.
 * 4. When a web service receives user‑submitted CDR images, normalizes their orientation, applies a Gaussian blur filter for visual effect, and returns the output as a TIFF for downstream imaging pipelines.
 * 5. When an automated quality‑control script validates CDR files by deskewing them, applying a Gaussian blur to simulate printing conditions, and saving the outcome as TIFF for further analysis.
 */