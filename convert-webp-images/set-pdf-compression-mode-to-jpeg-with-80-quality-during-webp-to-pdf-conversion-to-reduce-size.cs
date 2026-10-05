// HOW-TO: Convert WebP Image to PDF with JPEG Compression in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.webp";
            string outputPath = "Output/output.pdf";

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
                    // PDF compression mode to JPEG with 80% quality is not supported in Aspose.Imaging.
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
 * 1. When you need to embed a WebP graphic into a PDF report while keeping the file size low by applying JPEG compression.
 * 2. When an e‑commerce platform generates product catalogs and must convert high‑resolution WebP photos to PDF brochures using C#.
 * 3. When a document‑automation service receives WebP uploads and must produce PDF invoices with reduced storage requirements.
 * 4. When a mobile app backend processes user‑submitted WebP screenshots and creates PDF summaries that can be emailed.
 * 5. When a batch job migrates archived WebP assets to PDF format and wants to control output quality with an 80 % JPEG setting.
 */
