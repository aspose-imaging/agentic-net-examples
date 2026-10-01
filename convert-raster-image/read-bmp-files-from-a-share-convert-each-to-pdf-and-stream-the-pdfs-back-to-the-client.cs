// HOW-TO: Batch Convert BMP Files to PDF and Stream to Client in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = @"\\share\input";
            string outputDirectory = @"C:\output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.bmp"))
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP and convert to PDF
                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }

                // Stream the generated PDF back to the client (stdout in this example)
                using (FileStream pdfStream = File.OpenRead(outputPath))
                {
                    pdfStream.CopyTo(Console.OpenStandardOutput());
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
 * 1. When a web service needs to read BMP images from a network share, convert them to PDF for archival, and send the PDFs directly to the requester.
 * 2. When an automated batch job must process multiple BMP scans, generate PDF reports, and pipe the results to another system via standard output.
 * 3. When a desktop application has to transform user‑uploaded BMP pictures into PDF documents and immediately stream them back without saving intermediate files.
 * 4. When a document management workflow requires converting legacy BMP graphics stored on a file server into searchable PDF files for indexing.
 * 5. When a cloud function processes BMP assets from a shared folder, creates PDF versions, and returns them to a client application over a network stream.
 */
