// HOW-TO: Batch Convert CDR Files to High Quality PDF with AntiAlias Text Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!string.Equals(Path.GetExtension(inputPath), ".cdr", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.AntiAlias,
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
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
 * 1. When a design studio needs to automatically turn multiple CorelDRAW (.cdr) drawings into printable PDFs with smooth, anti‑aliased text.
 * 2. When a document management system must batch‑export archived CDR assets to PDF while preserving text clarity using anti‑aliasing.
 * 3. When an automated build pipeline generates PDF previews of CDR files for web viewers without manual conversion.
 * 4. When a reporting tool creates high‑resolution PDF reports from a folder of CDR diagrams, ensuring the text looks crisp.
 * 5. When a migration script moves legacy CDR graphics to PDF format for compliance, applying a white background and anti‑aliased text rendering.
 */
