// HOW-TO: Batch Convert Up to 20 DjVu Files to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

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

            foreach (var inputPath in files.Take(20))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        djvu.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to automatically transform a collection of scanned DjVu documents into PDF files for archiving or sharing.
 * 2. When a migration script must process the first twenty DjVu images in a folder and output PDFs using default settings.
 * 3. When integrating Aspose.Imaging into a C# backend to generate PDF versions of DjVu manuals for distribution to users.
 * 4. When building a batch conversion tool that creates PDF equivalents of DjVu files for compatibility with standard PDF viewers.
 * 5. When automating a document workflow that requires converting multiple DjVu pages to PDF before applying further processing such as OCR.
 */
