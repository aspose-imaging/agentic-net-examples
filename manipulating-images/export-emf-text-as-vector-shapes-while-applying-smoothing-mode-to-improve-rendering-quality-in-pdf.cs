// HOW-TO: Export EMF to PDF with Anti‑Aliased Vector Text in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                var rasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                emfImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to convert Windows Metafile (EMF) graphics to a PDF while preserving editable vector shapes for high‑quality printing.
 * 2. When you want to ensure that text and lines from an EMF are rendered smoothly in the resulting PDF by applying anti‑aliasing.
 * 3. When you are generating PDF reports from legacy EMF diagrams and require the output to remain scalable without rasterizing the artwork.
 * 4. When you need to programmatically batch‑process EMF files into PDFs in a .NET application, maintaining vector fidelity and improved rendering.
 * 5. When you are integrating Aspose.Imaging into a workflow that converts design assets to PDF and you must control smoothing and text rendering options for visual consistency.
 */
