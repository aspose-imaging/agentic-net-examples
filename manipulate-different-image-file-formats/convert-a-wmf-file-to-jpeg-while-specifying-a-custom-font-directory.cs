// HOW-TO: Convert WMF to JPEG With Custom Font Folder In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.jpg";
        string customFontDir = @"C:\CustomFonts";

        try
        {
            // Set custom font directory for vector rendering
            FontSettings.SetFontsFolder(customFontDir);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG save options
                var jpegOptions = new JpegOptions
                {
                    // Example: set quality (optional)
                    Quality = 90
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to render legacy WMF vector graphics as high‑quality JPEGs for web display while using fonts that are not installed on the server.
 * 2. When a batch conversion tool must process WMF files that reference corporate typefaces stored in a separate fonts directory.
 * 3. When generating thumbnails of WMF diagrams for a reporting dashboard and the required fonts are located in a custom folder.
 * 4. When automating document migration from old Windows Metafile assets to JPEG images in a .NET application that cannot rely on system‑wide font installations.
 * 5. When creating printable JPEG versions of WMF logos for marketing material and you must ensure the correct custom fonts are applied during rendering.
 */
