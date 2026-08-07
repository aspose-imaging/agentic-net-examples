// HOW-TO: Export PSD to TIFF with Correct Embedded Fonts Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.psd";
        string outputPath = "output.tif";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create output directory (if any) unconditionally
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Configure font settings so that fonts used in the PSD are available
            // Adjust the folder path to a location that contains the required fonts
            FontSettings.SetFontsFolder(@"C:\Windows\Fonts");
            FontSettings.UpdateFonts();

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the image as TIFF with the configured options
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
 * 1. When a designer needs to convert layered PSD files to high‑resolution TIFFs for print production while preserving the exact appearance of custom fonts.
 * 2. When an automated workflow must generate archival TIFF images from Photoshop documents on a server that does not have the original font files installed.
 * 3. When a web service creates preview TIFFs of user‑uploaded PSDs and must ensure the text renders with the same typefaces as in the source file.
 * 4. When a batch‑processing tool prepares TIFF assets for a digital asset management system and has to embed missing fonts to avoid font substitution errors.
 * 5. When a desktop application exports PSD artwork to TIFF for OCR or PDF conversion and needs the fonts to be available so the text remains searchable and selectable.
 */
