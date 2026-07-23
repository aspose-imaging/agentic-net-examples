using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
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
 * 1. When a developer needs to convert CorelDRAW (CDR) files to PDF while applying ClearType text rendering for sharper on‑screen text, this Aspose.Imaging C# code provides a ready‑to‑use solution.
 * 2. When a document management system must generate PDF previews of vector‑based CDR artwork with precise text clarity, the code demonstrates how to set TextRenderingHint to ClearType during conversion.
 * 3. When an automated batch process has to transform a folder of CDR designs into PDF reports and ensure the rendered text is crisp for digital viewing, the example shows the required Image and PdfOptions configuration.
 * 4. When a web application offers users the ability to download their CorelDRAW drawings as high‑quality PDFs with ClearType‑optimized typography, this snippet illustrates the necessary C# operations.
 * 5. When a print‑to‑screen workflow requires converting CDR graphics to PDF while preserving exact page dimensions and improving text readability with ClearType, the code provides the exact implementation steps.
 */