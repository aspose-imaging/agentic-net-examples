using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Output\sample.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure multiple font directories (example: Latin and CJK scripts)
            string[] fontFolders = new string[]
            {
                @"C:\Fonts\Latin",
                @"C:\Fonts\CJK"
            };
            // Set the font folders and enable recursive search
            FontSettings.SetFontsFolders(fontFolders, true);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PDF saving options
                var pdfOptions = new PdfOptions();

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert multi‑language TIFF scans (e.g., documents containing both Latin and CJK characters) to searchable PDF files and must point Aspose.Imaging to separate font folders so the correct glyphs are rendered.
 * 2. When an automated document‑processing service processes archived TIFF images from different regions and must ensure the PDF output uses the appropriate regional fonts stored in distinct directories.
 * 3. When building a desktop C# application that generates PDFs from user‑uploaded TIFF files and the application must support custom corporate fonts located in multiple folder paths.
 * 4. When integrating Aspose.Imaging into a batch conversion pipeline that reads TIFF files with embedded text and requires recursive loading of fonts from both a standard system folder and a network share to preserve text appearance in the resulting PDF.
 * 5. When creating a multilingual e‑learning platform that converts scanned lecture notes (TIFF) to PDF and needs to configure FontSettings to include both Latin and Asian font directories to avoid missing characters.
 */