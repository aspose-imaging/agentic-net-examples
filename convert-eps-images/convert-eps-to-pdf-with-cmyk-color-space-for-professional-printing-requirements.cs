// HOW-TO: Convert EPS to PDF with CMYK Color Space in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/result.pdf";

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
 * 1. When you need to transform a vector EPS artwork into a print‑ready PDF while preserving CMYK colors for a commercial printing workflow in a C# application.
 * 2. When an automated publishing system must generate PDF proofs from designer‑provided EPS files without losing color fidelity using Aspose.Imaging.
 * 3. When a web service receives EPS logos from clients and must return PDF versions suitable for high‑resolution brochures or flyers.
 * 4. When a desktop utility needs to batch‑convert multiple EPS files to PDFs for pre‑press preparation, ensuring the output uses the CMYK color space.
 * 5. When integrating a document management solution that stores PDFs, you may need to convert incoming EPS assets on the fly in .NET to maintain consistent color profiles.
 */
