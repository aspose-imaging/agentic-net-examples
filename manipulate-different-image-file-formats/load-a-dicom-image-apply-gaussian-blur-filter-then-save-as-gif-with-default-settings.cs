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
            string inputPath = "input.dcm";
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to use filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as GIF using default settings
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
 * 1. When a medical imaging application needs to convert a DICOM scan to a lightweight GIF for quick preview in a web portal, applying a Gaussian blur to reduce noise before display.
 * 2. When a radiology workflow requires batch processing of DICOM files to generate animated GIF thumbnails with softened edges for inclusion in patient reports.
 * 3. When a healthcare mobile app must load a DICOM image, smooth it with a Gaussian blur to hide sensitive details, and save it as a GIF for secure sharing.
 * 4. When a diagnostic software tool wants to demonstrate image filtering effects by loading a DICOM image, applying a blur filter, and exporting the result as a GIF for documentation.
 * 5. When a C# developer needs to integrate Aspose.Imaging to read DICOM files, apply a Gaussian blur for visual enhancement, and output a GIF with default settings for compatibility with legacy systems.
 */