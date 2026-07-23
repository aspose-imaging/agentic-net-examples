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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\source.tif";
            string outputPath = @"C:\temp\output.png";

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
                // Save as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG to check alpha channel
            using (Image pngImage = Image.Load(outputPath))
            {
                var png = (PngImage)pngImage;
                bool hasAlpha = png.HasAlpha;
                Console.WriteLine($"PNG image '{outputPath}' has alpha channel: {hasAlpha}");
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
 * 1. When a developer needs to convert a multi‑page TIFF scan to a PNG for web display and verify whether the resulting PNG retains transparency for overlay purposes.
 * 2. When an image‑processing pipeline must ensure that PNG assets derived from TIFF sources contain an alpha channel before they are used in UI components that rely on translucency.
 * 3. When a batch conversion tool has to log the transparency status of each PNG generated from archival TIFF files to comply with quality‑assurance reporting.
 * 4. When a C# application integrates Aspose.Imaging to detect if a converted PNG includes an alpha channel, so it can decide whether to apply a background fill or preserve the original transparency.
 * 5. When a developer is troubleshooting why a PNG exported from a TIFF loses its transparency and needs to programmatically check the HasAlpha property after saving.
 */