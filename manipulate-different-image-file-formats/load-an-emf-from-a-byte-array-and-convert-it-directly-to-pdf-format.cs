// HOW-TO: Convert EMF Byte Array to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.emf");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] emfBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(emfBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
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
 * 1. When a Windows desktop application receives an EMF graphic as a byte stream from a database and needs to generate a printable PDF report.
 * 2. When a web service uploads EMF files via an API, stores them in memory, and must return a PDF version to the client without writing intermediate files.
 * 3. When an automated document workflow extracts embedded EMF images from Office documents and converts them directly to PDF for archiving.
 * 4. When a batch job processes a folder of EMF icons loaded into memory and creates a single PDF catalog for distribution.
 * 5. When a mobile backend receives EMF data from a client device, converts it to PDF for email attachment or cloud storage.
 */
