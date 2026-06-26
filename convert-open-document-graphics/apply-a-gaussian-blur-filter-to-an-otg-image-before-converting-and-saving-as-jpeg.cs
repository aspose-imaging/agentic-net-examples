using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size=5, sigma=4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to soften the details of a high‑resolution OTG vector graphic before delivering it as a compressed JPEG for web preview.
 * 2. When an automated image pipeline must apply a Gaussian blur to an OTG file to reduce noise and then convert it to JPEG for storage in a content‑management system.
 * 3. When a desktop application processes scanned OTG documents, blurs sensitive information, and saves the result as a JPEG for email attachment.
 * 4. When a batch job reads OTG assets, applies a 5‑pixel Gaussian blur with sigma 4.0 to meet branding guidelines, and outputs JPEG files for mobile devices.
 * 5. When a C# service integrates Aspose.Imaging to transform OTG artwork into JPEG thumbnails with a blur effect to improve loading speed on e‑commerce sites.
 */