// HOW-TO: Render CorelDRAW CDR to PDF with Custom Font Folder in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input, output, and custom font folder paths
        string inputPath = @"C:\Input\sample.cdr";
        string outputPath = @"C:\Output\sample.pdf";
        string fontFolder = @"C:\Fonts";

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

            // Register custom font folder and update font cache
            FontSettings.SetFontsFolder(fontFolder);
            FontSettings.UpdateFonts();

            // Load the CDR document
            using (Image image = Image.Load(inputPath, new LoadOptions()))
            {
                // Configure rasterization options for vector rendering
                var rasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Set PDF save options with the rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the document as PDF
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
 * 1. When you need to convert a CorelDRAW CDR file to PDF using Aspose.Imaging while ensuring that text uses fonts stored in a private directory on the server.
 * 2. When a web application must generate PDF previews of CDR designs with Aspose.Imaging and you have to supply custom corporate fonts that are not installed on the host machine.
 * 3. When automating batch processing of CDR assets with Aspose.Imaging and you must guarantee consistent typography by registering a specific fonts folder before rasterizing each file.
 * 4. When integrating Aspose.Imaging into a CI/CD pipeline where the build environment lacks system fonts, so you provide a custom font folder to avoid missing‑glyph errors in the resulting PDFs.
 * 5. When creating a desktop utility that lets users select a font collection folder and then export their CorelDRAW drawings to PDF with accurate text rendering using Aspose.Imaging.
 */
