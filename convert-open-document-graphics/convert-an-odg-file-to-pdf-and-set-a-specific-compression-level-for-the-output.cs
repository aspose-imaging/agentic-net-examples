// HOW-TO: Convert ODG to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Compression level setting is not supported by Aspose.Imaging for PDF.
                    // If required, handle accordingly (e.g., throw NotSupportedException).
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
 * 1. When a developer needs to generate a PDF report from an OpenDocument Graphics (ODG) drawing in a .NET application.
 * 2. When an automated document workflow must transform ODG assets into PDF for archival or distribution.
 * 3. When a C# service processes user‑uploaded ODG files and needs to deliver them as PDF for cross‑platform viewing.
 * 4. When a batch conversion tool has to convert multiple ODG files to PDF while handling missing files gracefully.
 * 5. When a developer wants to use Aspose.Imaging to load an ODG image and save it as PDF, acknowledging that custom compression settings are not currently supported.
 */
