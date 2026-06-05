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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\sample.GaussianBlur.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image; DPI (resolution) metadata is preserved automatically
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
 * 1. When a developer needs to blur a high‑resolution PNG for a web thumbnail while keeping the original DPI so the image prints at the correct size.
 * 2. When an automated batch job processes scanned documents, applying a Gaussian blur to reduce noise but must preserve the DPI metadata for downstream OCR tools.
 * 3. When a desktop application lets users apply artistic effects to photos and must ensure the saved JPEG or PNG retains its original resolution information for printing.
 * 4. When a server‑side service receives user‑uploaded images, applies a Gaussian blur for privacy masking, and must keep the DPI unchanged for compliance with publishing standards.
 * 5. When a C# utility prepares images for a digital signage system, using Aspose.Imaging to blur background elements while preserving DPI so the signage software scales the graphics accurately.
 */