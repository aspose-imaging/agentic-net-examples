// HOW-TO: Convert CDR to PNG with Maximum Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(outputPath, pngOptions);
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
 * 1. When a designer needs to deliver high‑resolution vector artwork from CorelDRAW as a compact PNG for web publishing.
 * 2. When an automated build pipeline must batch‑convert CDR files to PNG while minimizing file size for faster downloads.
 * 3. When a C# application has to generate thumbnail previews of CDR documents with lossless compression for email attachments.
 * 4. When a digital asset management system stores CDR assets and requires on‑the‑fly conversion to PNG with maximum compression for archival.
 * 5. When a reporting tool extracts pages from CDR files and saves them as PNG images with the smallest possible footprint for PDF embedding.
 */
