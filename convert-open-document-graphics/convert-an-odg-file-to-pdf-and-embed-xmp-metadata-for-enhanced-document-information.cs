// HOW-TO: Convert ODG to PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to programmatically convert OpenDocument graphics (ODG) files to PDF for cross‑platform viewing in a .NET application.
 * 2. When generating printable reports from ODG diagrams and exporting them as PDF documents on a server.
 * 3. When automating batch conversion of design assets stored as ODG into PDF for archival or distribution.
 * 4. When integrating ODG to PDF conversion into a document management workflow that requires C# code and Aspose.Imaging.
 * 5. When building a web service that receives ODG uploads and returns PDF files without manual user intervention.
 */
