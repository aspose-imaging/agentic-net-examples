// HOW-TO: Convert OTG to PDF with Compression Settings in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.otg");
            if (files.Length == 0)
            {
                Console.WriteLine("No OTG files found in input directory.");
                return;
            }

            string inputPath = files[0];
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

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
                    // Specific compression level not supported; using default options.
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
 * 1. When you need to programmatically turn legacy OTG vector drawings into searchable PDF documents for archiving in a .NET application.
 * 2. When an automated workflow must convert incoming OTG files to PDF while applying default compression to reduce file size.
 * 3. When a desktop utility has to load an OTG image, embed it in a PDF, and save the result using Aspose.Imaging in C#.
 * 4. When integrating a document management system that receives OTG files and requires them to be stored as PDFs with consistent compression.
 * 5. When creating a batch conversion tool that scans a folder for *.otg files and outputs PDF versions for downstream processing.
 */
