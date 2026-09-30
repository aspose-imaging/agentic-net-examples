// HOW-TO: Convert EPS With Text To Searchable PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace EpsToSearchablePdf
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.eps";
            string outputPath = "output.pdf";

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
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive vector artwork from EPS files while keeping the embedded text searchable in PDF documents.
 * 2. When a publishing workflow requires converting designer‑generated EPS files into PDFs that can be indexed by search engines.
 * 3. When you want to generate searchable PDF reports from EPS diagrams without rasterizing the text.
 * 4. When an application must batch‑process EPS assets and produce PDFs that retain selectable text for accessibility compliance.
 * 5. When integrating a C# service that transforms EPS logos into PDF brochures while preserving the original text for later editing.
 */
