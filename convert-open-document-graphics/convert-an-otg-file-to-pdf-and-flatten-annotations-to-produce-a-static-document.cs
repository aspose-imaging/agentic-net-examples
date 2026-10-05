// HOW-TO: Convert OTG File To PDF With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.otg");
            string outputPath = Path.Combine(baseDir, "Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions options = new PdfOptions())
                {
                    image.Save(outputPath, options);
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
 * 1. When you need to archive engineering drawings stored as OTG files into a universally viewable PDF for distribution.
 * 2. When a web application must generate static PDF reports from OTG images without preserving interactive annotation layers.
 * 3. When integrating a document workflow that receives OTG uploads and must convert them to PDF for downstream processing like OCR or printing.
 * 4. When migrating legacy OTG assets to a PDF format that requires flattened images to ensure consistent rendering across devices.
 * 5. When building a C# service that programmatically converts OTG files to PDF to comply with regulatory document‑format standards.
 */
