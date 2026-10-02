// HOW-TO: Convert CorelDRAW CDR to PDF with ClearType Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                var vectorOptions = new VectorRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                };
                pdfOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate PDF reports from CorelDRAW designs and want crisp, screen‑optimized text.
 * 2. When converting legacy CDR artwork to PDF for web preview while preserving ClearType text clarity.
 * 3. When automating batch processing of CDR files to PDFs in a C# application and require high‑quality text rendering.
 * 4. When integrating CorelDRAW assets into a document workflow that demands PDF output with sharp, readable fonts.
 * 5. When creating printable PDFs from vector graphics and want the text to appear smoother on Windows displays.
 */
