// HOW-TO: Save JPEG As PDF To Cloud Mapped Drive Folder In C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.jpg";
            string outputPath = @"Z:\CloudStorage\Converted\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When you need to automatically convert user‑uploaded JPEG photos to PDF documents and store them in a shared cloud folder accessed via a mapped network drive.
 * 2. When a batch job must process local image files and place the resulting PDFs into a centralized cloud‑based file share for downstream workflow automation.
 * 3. When an enterprise application saves scanned product images as PDFs directly to a cloud‑mapped folder to ensure all team members can retrieve them instantly.
 * 4. When you want to verify the existence of an input image, create the destination directory if missing, and then use Aspose.Imaging to generate a PDF in a cloud‑mapped location.
 * 5. When a C# service integrates with existing file‑system permissions and writes converted PDFs to a network‑mapped drive that syncs with cloud storage for backup and collaboration.
 */
