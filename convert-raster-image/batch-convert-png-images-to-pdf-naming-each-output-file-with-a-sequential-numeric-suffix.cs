// HOW-TO: Batch Convert Multiple PNG Files to Sequentially Named PDFs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchPngToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\Images\Input";
                string outputDirectory = @"C:\Images\Output";

                Directory.CreateDirectory(outputDirectory);

                string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

                for (int i = 0; i < pngFiles.Length; i++)
                {
                    string inputPath = pngFiles[i];
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, $"output_{i + 1}.pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PDF report from a folder of scanned PNG receipts, assigning each PDF a unique number.
 * 2. When an application must archive product images as PDFs for compliance, creating files like output_1.pdf, output_2.pdf, etc.
 * 3. When a web service processes user‑uploaded PNG screenshots and stores them as sequentially numbered PDF documents for easy retrieval.
 * 4. When a batch job converts PNG assets from a design pipeline into PDFs for printing, preserving order with numeric suffixes.
 * 5. When a desktop tool prepares a series of PNG diagrams for distribution by converting them to PDFs with consistent naming.
 */
