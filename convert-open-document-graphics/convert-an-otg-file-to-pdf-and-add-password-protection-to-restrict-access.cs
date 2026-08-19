// HOW-TO: Convert OTG to PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load OTG image and convert to PDF
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for OTG
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // NOTE: Aspose.Imaging does not provide a direct API for PDF password protection.
                // If password protection is required, consider using Aspose.PDF or another library.

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
 * 1. When you need to archive engineering drawings stored as OTG files by converting them to PDF documents in a C# application.
 * 2. When you want to generate PDF reports from OTG images while preserving original dimensions and background color using Aspose.Imaging.
 * 3. When an automated workflow must batch‑process OTG files into PDFs before uploading them to a document management system.
 * 4. When you need to protect the generated PDF with a password, you can extend this code by integrating Aspose.PDF to add encryption after conversion.
 * 5. When a desktop utility must validate the existence of OTG files, create output folders, and safely handle conversion errors in .NET.
 */
