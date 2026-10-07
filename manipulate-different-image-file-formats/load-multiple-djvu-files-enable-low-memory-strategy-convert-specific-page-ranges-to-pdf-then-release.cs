// HOW-TO: Convert Selected Pages of Multiple DjVu Files to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
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

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions { BufferSizeHint = 1024 * 1024 };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    var djvuImage = (DjvuImage)image;

                    using (var pdfOptions = new PdfOptions())
                    {
                        pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(0, 2));
                        djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑convert large DjVu documents to PDF while only keeping the first three pages to reduce file size.
 * 2. When a server‑side C# application must process many DjVu files with limited RAM by using a buffer‑size hint.
 * 3. When you want to extract a specific page range from each DjVu file and save it as a multi‑page PDF for archival.
 * 4. When automating a workflow that reads DjVu scans from an input folder, converts them to PDF, and stores the results in an output folder.
 * 5. When integrating Aspose.Imaging into a .NET service that must release resources promptly after converting DjVu to PDF to avoid memory leaks.
 */
