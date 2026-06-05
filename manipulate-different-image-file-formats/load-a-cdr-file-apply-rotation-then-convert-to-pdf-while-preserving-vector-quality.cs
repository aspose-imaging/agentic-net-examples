using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Rotate(90f);

                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a graphic designer needs to rotate a CorelDRAW (CDR) illustration by 90 degrees and export it as a high‑quality PDF without losing vector fidelity, this code can automate the process in a C# application.
 * 2. When an automated document workflow must convert archived CDR files to searchable PDFs while preserving exact positioning of text and shapes, the snippet provides the necessary rotation and vector rasterization steps.
 * 3. When a batch‑processing service has to generate printable PDFs from rotated CDR assets for a printing press, developers can use this code to maintain crisp vector edges and correct orientation.
 * 4. When a web API receives user‑uploaded CDR logos that need to be displayed in portrait orientation as PDFs on a portal, the example shows how to rotate and convert the files while keeping them scalable.
 * 5. When a migration tool moves legacy CorelDRAW designs into a PDF‑based archive and must ensure the drawings are rotated correctly and retain their original vector quality, this C# routine performs the conversion efficiently.
 */