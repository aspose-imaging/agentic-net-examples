// HOW-TO: Rotate CorelDRAW CDR and Convert to Vector PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                cdr.RotateFlip(RotateFlipType.Rotate90FlipNone);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };

                    cdr.Save(outputPath, pdfOptions);
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
 * 1. When a C# application must take a CorelDRAW (.cdr) design, rotate it 90°, and output a high‑quality PDF that retains the vector data for printing or sharing.
 * 2. When you need to programmatically generate PDF catalogs from rotated CDR artwork without rasterizing the graphics, using Aspose.Imaging in .NET.
 * 3. When an automated workflow has to validate that a CDR file exists, apply a specific orientation, and convert it to a PDF for archival while preserving exact dimensions.
 * 4. When a desktop tool must batch‑process CorelDRAW files, apply a uniform rotation, and produce PDF files that keep the original page width and height for layout consistency.
 * 5. When integrating CorelDRAW assets into a .NET reporting system, you need to rotate the image and embed it as a vector PDF to ensure crisp rendering on all devices.
 */
