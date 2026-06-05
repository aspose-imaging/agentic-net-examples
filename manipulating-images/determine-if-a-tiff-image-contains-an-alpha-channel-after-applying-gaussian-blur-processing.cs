using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.png";

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
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur filter to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);

                // Determine if the image has an alpha channel after processing
                bool hasAlpha = tiffImage.HasAlpha;
                Console.WriteLine($"HasAlpha after blur: {hasAlpha}");
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
 * 1. When converting scanned TIFF documents with transparent layers to PNG after applying a Gaussian blur for noise reduction, a developer needs to verify if the resulting image still contains an alpha channel.
 * 2. When building a C# web service that processes medical imaging TIFF files, applies a Gaussian blur to smooth artifacts, and then checks for alpha transparency before sending PNG output to clients.
 * 3. When creating an automated batch job that reads high‑resolution TIFF photographs, applies a Gaussian blur filter, saves them as PNG, and logs whether the processed images retain an alpha channel for downstream compositing.
 * 4. When developing a desktop application that lets users edit archival TIFF maps, applies a Gaussian blur to soften edges, and must determine if the map still includes transparency before exporting to PNG.
 * 5. When implementing a document‑management workflow that ingests TIFF files, applies a Gaussian blur to obscure sensitive details, and needs to confirm the presence of an alpha channel to decide if additional masking steps are required.
 */