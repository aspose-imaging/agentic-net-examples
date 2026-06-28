using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input PSD, output PNG and custom fonts folder
            string inputPath = @"C:\Images\sample.psd";
            string outputPath = @"C:\Images\output\sample.png";
            string fontsFolder = @"C:\CustomFonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register custom fonts folder and refresh the font cache for PSD processing
            FontSettings.SetFontsFolder(fontsFolder);
            FontSettings.UpdateFonts();

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG preserving text appearance
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a web‑based design review tool needs to convert client‑provided Photoshop PSD files that use proprietary fonts into PNG thumbnails while preserving the exact text layout.
 * 2. When an automated build pipeline generates product screenshots from PSD mockups that rely on corporate brand fonts stored in a custom directory.
 * 3. When a digital asset management system imports PSD artwork and must render it as PNG for preview, ensuring that any embedded text appears correctly even if the system fonts are missing.
 * 4. When a Windows desktop application batch‑processes a folder of PSD files containing custom typography and outputs PNG files for use in marketing collateral.
 * 5. When a cloud service receives PSD uploads with licensed fonts and needs to rasterize them to PNG on the server without installing the fonts system‑wide.
 */