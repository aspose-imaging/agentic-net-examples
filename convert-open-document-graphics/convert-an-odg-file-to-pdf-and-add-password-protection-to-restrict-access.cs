using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.odg";
        string outputPath = @"C:\Output\sample.pdf";

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

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG to PDF conversion
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Set up PDF save options and attach rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Embed a digital signature (password protection) into each page
                const string password = "mySecretPassword";
                if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.EmbedDigitalSignature(password);
                }

                // Save the image as PDF with the specified options
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) file to a PDF and apply password protection for secure client delivery, this code provides a straightforward C# solution using Aspose.Imaging.
 * 2. When a business wants to archive multi‑page ODG drawings as encrypted PDFs to comply with data‑privacy regulations, the example demonstrates how to rasterize and embed a digital signature in C#.
 * 3. When an engineering team must share design schematics stored in ODG format with external partners while restricting access, they can use this code to generate a password‑protected PDF via Aspose.Imaging’s PdfOptions.
 * 4. When an automated workflow processes incoming ODG files and needs to output read‑only PDFs that require a password to open, the snippet shows the necessary file handling and rasterization steps in .NET.
 * 5. When a developer is building a document management system that converts ODG drawings to secure PDFs for storage in a protected repository, this example illustrates the required C# operations and image processing concepts.
 */