using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.tif";
        string outputPath = @"C:\temp\converted.png";

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
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Convert and save as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG image
            using (Image pngImage = Image.Load(outputPath))
            {
                var png = (PngImage)pngImage;
                // Log transparency status
                Console.WriteLine($"PNG HasAlpha: {png.HasAlpha}");
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
 * 1. When a developer needs to convert multi‑page TIFF scans to PNG for web display and must verify whether the resulting PNG retains any transparency before embedding it in a webpage.
 * 2. When an automated image‑processing pipeline must detect if a PNG created from a TIFF source contains an alpha channel so it can decide whether to apply a background fill for PDF generation.
 * 3. When a desktop application that imports legacy TIFF assets needs to log the transparency status of the exported PNG to troubleshoot rendering issues in UI controls.
 * 4. When a batch job processes medical imaging TIFF files and must record whether the converted PNG images have an alpha channel to comply with a downstream analysis tool’s format requirements.
 * 5. When a cloud service that receives TIFF uploads converts them to PNG and needs to programmatically check and store the HasAlpha flag for audit and metadata purposes.
 */