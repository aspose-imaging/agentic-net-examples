// HOW-TO: Convert PSD to PDF with Anti-Alias Smoothing and Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                    }
                };

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
 * 1. When you need to generate a print‑ready PDF from a Photoshop PSD while preserving smooth edges and crisp text.
 * 2. When exporting design mockups to PDF for client review and you want anti‑aliased graphics to look professional.
 * 3. When archiving layered artwork as PDF and require consistent text rendering across different viewers.
 * 4. When automating batch conversion of PSD files to PDF in a C# application and need optimal visual quality.
 * 5. When integrating Aspose.Imaging into a workflow that creates PDFs for e‑learning materials with clear, anti‑aliased typography.
 */
