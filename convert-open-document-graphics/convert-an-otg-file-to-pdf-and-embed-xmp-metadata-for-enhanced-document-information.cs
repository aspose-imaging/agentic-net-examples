// HOW-TO: Convert OTG File To PDF Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
 * 1. When a medical imaging system stores scans in OTG format and needs to generate PDF reports for clinicians.
 * 2. When an e‑learning platform must batch‑convert OTG illustrations into PDF handouts for offline distribution.
 * 3. When a document management workflow requires embedding OTG graphics into searchable PDF archives for compliance.
 * 4. When a desktop application needs to let users export OTG design files as PDFs for printing or sharing.
 * 5. When an automated build process must transform OTG assets into PDF format to include them in generated documentation.
 */
