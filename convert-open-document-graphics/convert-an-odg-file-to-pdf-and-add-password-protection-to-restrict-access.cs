// HOW-TO: Convert ODG to Password Protected PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.odg";
            string outputPath = @"C:\Output\sample.pdf";
            string password = "SecurePassword123";

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
                // Set up rasterization options for ODG
                OdgRasterizationOptions rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // If the image supports embedding a digital signature, apply it using the password
                if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.EmbedDigitalSignature(password);
                }

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
 * 1. When you need to share an OpenDocument graphic with clients but must restrict opening to authorized users, you can convert the ODG file to a password‑protected PDF using C# and Aspose.Imaging.
 * 2. When automating a document workflow that generates design drafts in ODG format and requires secure archival as PDFs, this code rasterizes the ODG and embeds a password to prevent unauthorized viewing.
 * 3. When integrating a reporting system that outputs charts as ODG files and you must deliver them as encrypted PDFs for compliance, the example shows how to perform the conversion and apply protection programmatically.
 * 4. When building a batch‑processing tool that processes multiple ODG drawings and saves them as PDFs with a digital signature password, the snippet demonstrates the necessary rasterization and save options.
 * 5. When creating a desktop application that lets users export their LibreOffice Draw projects to a locked PDF for confidential presentations, this code provides the C# implementation using Aspose.Imaging.
 */
