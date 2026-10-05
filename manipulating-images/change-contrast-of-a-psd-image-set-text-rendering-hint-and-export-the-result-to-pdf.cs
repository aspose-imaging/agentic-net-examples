// HOW-TO: Convert PSD to PDF with Single Bit Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
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
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                    };

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
 * 1. When you need to generate a PDF from a Photoshop PSD file while ensuring that all text is rasterized using a single‑bit per pixel hint for sharper on‑screen rendering.
 * 2. When you want to programmatically convert layered PSD artwork to a PDF for printing or archiving without losing vector text quality.
 * 3. When an application must batch‑process PSD files and output PDFs that use a specific text rendering mode to meet accessibility or file‑size requirements.
 * 4. When you are building a C# service that receives PSD uploads and returns PDF previews with optimized text rendering for low‑resolution displays.
 * 5. When you need to automate the conversion of design assets from PSD to PDF while controlling rasterization options such as text rendering hints.
 */
