// HOW-TO: Convert ODG to PDF with Embedded Fonts Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.odg";
        string outputPath = @"C:\output\sample.pdf";

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

            // Optional: set custom fonts folder to embed required fonts
            // Adjust the path to point to a folder containing the needed TrueType fonts
            string fontsFolder = @"C:\Fonts";
            FontSettings.SetFontsFolder(fontsFolder);
            FontSettings.UpdateFonts();

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the image as PDF with embedded fonts
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
 * 1. When you need to generate a PDF from an OpenDocument Graphics (ODG) file in a C# application while preserving the original text appearance by embedding the required fonts.
 * 2. When a document management system must automatically convert user‑uploaded ODG diagrams to searchable PDFs with all fonts included to avoid missing‑font warnings on client machines.
 * 3. When creating batch processing scripts that convert multiple ODG files to PDF on a server and ensure consistent rendering by specifying a custom fonts folder.
 * 4. When integrating Aspose.Imaging into a reporting tool that outputs design assets as PDFs and must embed TrueType fonts to meet corporate branding guidelines.
 * 5. When developing a Windows service that monitors a folder for new ODG files, converts them to PDF, and embeds fonts to guarantee accurate printing on any printer.
 */
