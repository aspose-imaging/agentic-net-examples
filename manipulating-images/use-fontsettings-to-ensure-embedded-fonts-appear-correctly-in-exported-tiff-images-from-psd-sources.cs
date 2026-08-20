// HOW-TO: Export PSD to TIFF with Correct Embedded Font Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.psd";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure font settings so that embedded fonts are rendered correctly
            FontSettings.DefaultFontName = "Arial"; // fallback font
            FontSettings.UpdateFonts(); // apply changes

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert layered Photoshop files to high‑resolution TIFFs for printing while preserving the appearance of embedded text fonts.
 * 2. When an automated workflow must generate archival TIFF images from PSD sources and ensure fallback fonts are applied if the original fonts are missing.
 * 3. When a web service creates downloadable TIFF previews of PSD designs and must render text consistently across different servers.
 * 4. When a desktop application batch‑processes PSD assets into TIFF format for a digital asset management system and requires reliable font rendering.
 * 5. When integrating Aspose.Imaging into a C# project to produce TIFF files from PSD files that contain custom fonts, guaranteeing the output looks identical to the source.
 */
