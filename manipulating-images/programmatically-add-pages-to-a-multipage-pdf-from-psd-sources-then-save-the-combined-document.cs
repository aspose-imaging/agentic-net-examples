// HOW-TO: Combine Multiple PSD Files Into a Single Multipage PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = { "Input/source1.psd", "Input/source2.psd" };
            string outputPath = "Output/combined.pdf";

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var images = new List<Image>();
            foreach (var inputPath in inputPaths)
            {
                Image img = Image.Load(inputPath);
                images.Add(img);
            }

            using (Image pdf = Image.Create(images.ToArray(), true))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdf.Save(outputPath, pdfOptions);
                }
            }

            foreach (var img in images)
            {
                img.Dispose();
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
 * 1. When you need to merge several Photoshop PSD designs into one searchable PDF report for client review.
 * 2. When automating the creation of a product catalog by converting each PSD artwork page into a separate PDF page.
 * 3. When generating printable manuals where each chapter is stored as a PSD file and must be combined into a single PDF document.
 * 4. When building a server‑side service that receives PSD uploads and returns a multi‑page PDF for archival or distribution.
 * 5. When consolidating marketing assets, such as PSD banners, into a single PDF portfolio for easy sharing with stakeholders.
 */
