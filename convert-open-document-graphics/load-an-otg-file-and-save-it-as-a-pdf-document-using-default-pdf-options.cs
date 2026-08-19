// HOW-TO: Convert OTG Image to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.otg";
            string outputPath = @"C:\Data\Result\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options with default rasterization settings
                var pdfOptions = new PdfOptions();

                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Use the source image size as the page size
                    PageSize = image.Size
                };

                pdfOptions.VectorRasterizationOptions = otgRasterizationOptions;

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
 * 1. When you need to generate a printable PDF from a proprietary OTG vector graphic in a .NET application.
 * 2. When automating batch processing of OTG files to archive them as PDF documents on a server.
 * 3. When integrating Aspose.Imaging into a document management system to preview OTG drawings as PDFs for end users.
 * 4. When converting OTG images to PDF with default page size to preserve original dimensions for reporting tools.
 * 5. When building a C# service that receives OTG uploads and returns PDF files for downstream workflows.
 */
