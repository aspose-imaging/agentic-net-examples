// HOW-TO: Convert Multiple CorelDRAW CDR Files to Separate PDF Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input CDR file paths (hardcoded)
            string cdrPath1 = "Input/file1.cdr";
            string cdrPath2 = "Input/file2.cdr";
            string cdrPath3 = "Input/file3.cdr";

            // Validate input files
            if (!File.Exists(cdrPath1))
            {
                Console.Error.WriteLine($"File not found: {cdrPath1}");
                return;
            }
            if (!File.Exists(cdrPath2))
            {
                Console.Error.WriteLine($"File not found: {cdrPath2}");
                return;
            }
            if (!File.Exists(cdrPath3))
            {
                Console.Error.WriteLine($"File not found: {cdrPath3}");
                return;
            }

            // Output PDF directory
            string outputDir = Path.GetDirectoryName("Output/combined.pdf");
            Directory.CreateDirectory(outputDir);

            // Convert each CDR to a separate PDF page file
            ConvertCdrToPdf(cdrPath1, "Output/page1.pdf");
            ConvertCdrToPdf(cdrPath2, "Output/page2.pdf");
            ConvertCdrToPdf(cdrPath3, "Output/page3.pdf");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertCdrToPdf(string inputPath, string outputPath)
    {
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image cdrImage = Image.Load(inputPath))
        {
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                cdrImage.Save(outputPath, pdfOptions);
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert a set of CorelDRAW (.cdr) drawings into individual PDF pages for printing or archiving.
 * 2. When an automated workflow must validate the existence of each CDR file before creating PDF equivalents to avoid runtime errors.
 * 3. When you want to generate PDF files in a specific output folder structure, ensuring each source CDR has its own PDF page.
 * 4. When integrating Aspose.Imaging into a C# application to transform vector graphics into PDF format without manual user interaction.
 * 5. When preparing separate PDF pages that will later be merged into a multi‑page document using another tool or library.
 */
