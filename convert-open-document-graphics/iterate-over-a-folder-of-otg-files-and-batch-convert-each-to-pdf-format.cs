// HOW-TO: Batch Convert Multiple OTG Files to PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\OtgInput";
            string outputFolder = @"C:\PdfOutput";

            // Get all OTG files in the input folder
            string[] otgFiles = Directory.GetFiles(inputFolder, "*.otg");

            foreach (string inputPath in otgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the OTG image and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options for OTG
                    OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to automatically transform a collection of OTG design drawings into searchable PDF documents for archiving or distribution.
 * 2. When a printing workflow requires converting all OTG files in a directory to PDF before sending them to a print service.
 * 3. When you want to generate PDF reports from OTG images produced by an engineering application without manually opening each file.
 * 4. When a migration project moves legacy OTG assets to a PDF‑based documentation system and you need a script to process them in bulk.
 * 5. When a web application must serve OTG content as PDF to browsers, and you need to pre‑convert an entire folder of files on the server.
 */
