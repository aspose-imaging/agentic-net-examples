// HOW-TO: Convert Single‑Page CDR to PDF With Vector Data In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CdrToPdfConverter
{
    class Program
    {
        static void Main()
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

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions options = new PdfOptions();
                    image.Save(outputPath, options);
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
 * 1. When a designer needs to embed a CorelDRAW (CDR) illustration into a printable PDF without rasterizing the vector graphics.
 * 2. When an automated workflow must convert single‑page CDR files to PDF for archival or distribution using C# and Aspose.Imaging.
 * 3. When a web service receives CDR uploads and must generate PDF previews while preserving the original vector quality.
 * 4. When a batch job processes a folder of CDR assets and creates PDF versions for inclusion in a digital catalog.
 * 5. When a desktop application needs to validate the existence of a CDR file, convert it to PDF, and handle errors gracefully in .NET.
 */
