using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

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

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                var tiffImage = (TiffImage)image;

                // Apply Gaussian blur filter to the entire image
                tiffImage.Filter(tiffImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Determine if the image has an alpha channel after processing
                bool hasAlpha = tiffImage.HasAlpha;
                Console.WriteLine($"HasAlpha after blur: {hasAlpha}");

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to preprocess a high‑resolution scanned TIFF document by applying a Gaussian blur to reduce noise before OCR and must verify whether the blur introduced an alpha channel before converting it to PNG.
 * 2. When building a medical imaging workflow that receives TIFF radiology images, applies a Gaussian blur for anonymization, and checks for an alpha channel to ensure the resulting PNG can be displayed correctly in web viewers.
 * 3. When creating a batch conversion tool that smooths satellite TIFF imagery with a Gaussian blur, determines if any transparency (alpha) was added, and then saves the cleaned image as a PNG for GIS applications.
 * 4. When developing a document management system that accepts user‑uploaded TIFF files, applies a Gaussian blur to mask sensitive details, and needs to confirm the presence of an alpha channel before storing the image as a PNG thumbnail.
 * 5. When implementing a graphics pipeline that converts legacy TIFF assets to PNG, applies a Gaussian blur for artistic effect, and checks the HasAlpha property to decide whether additional compositing steps are required.
 */