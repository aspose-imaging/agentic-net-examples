// HOW-TO: Resize PNG to 1024x768 and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input/image.png";
                string outputPath = "Output/resized.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Resize(1024, 768);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF report that includes a PNG logo scaled to a standard 1024×768 size for consistent layout.
 * 2. When an e‑commerce platform must convert product thumbnail PNGs into PDF catalogs while ensuring all images fit a predefined page dimension.
 * 3. When a document automation system requires resizing user‑uploaded PNG signatures before embedding them into PDF contracts.
 * 4. When a batch processing tool must shrink large PNG screenshots to 1024×768 and archive them as PDF files to save storage space.
 * 5. When a web service needs to deliver printable PDFs from PNG assets, ensuring the images are resized to fit standard A4‑like dimensions.
 */
