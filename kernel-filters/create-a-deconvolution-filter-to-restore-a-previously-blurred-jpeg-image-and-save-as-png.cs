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
            string inputPath = @"C:\Images\blurred.jpg";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the blurred JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to enable filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create a Gauss-Wiener deconvolution filter (radius=5, sigma=4.0)
                var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, deconvOptions);

                // Save the restored image as PNG
                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to restore a JPEG photo that was unintentionally blurred during capture or transmission, they can use this deconvolution filter to sharpen the image and save the result as a lossless PNG.
 * 2. When building an automated image‑processing pipeline that ingests scanned JPEG documents and must improve readability before archiving, the code can deblur each page and output PNG files for higher quality storage.
 * 3. When creating a web service that accepts user‑uploaded blurred pictures and returns a cleaned‑up version, the Gauss‑Wiener filter in C# can be applied to the image and the restored PNG can be sent back to the client.
 * 4. When integrating Aspose.Imaging into a desktop application that repairs old family photos saved as JPEGs, developers can apply the deconvolution filter to remove blur and export the corrected image as PNG for printing.
 * 5. When performing batch processing of product catalog images that suffered motion blur during photography, the code can loop through JPEG files, apply the Gauss‑Wiener deconvolution, and save the sharpened results as PNG for e‑commerce platforms.
 */