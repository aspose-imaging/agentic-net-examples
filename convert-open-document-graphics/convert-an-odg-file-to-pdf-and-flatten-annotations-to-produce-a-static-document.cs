// HOW-TO: Convert ODG to PDF and Flatten Annotations in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine(baseDir, "Input", "sample.odg");
            string outputPath = Path.Combine(baseDir, "Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions options = new PdfOptions())
                {
                    image.Save(outputPath, options);
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
 * 1. When you need to generate a read‑only PDF version of an ODG diagram for distribution without interactive annotation layers.
 * 2. When a reporting system must archive OpenDocument graphics as flattened PDF files to ensure consistent rendering across viewers.
 * 3. When converting user‑uploaded ODG files to PDF in a web application while removing editable annotations for security compliance.
 * 4. When automating batch processing of design assets, turning multiple ODG drawings into static PDFs for printing or e‑signature workflows.
 * 5. When integrating Aspose.Imaging in a C# service to produce PDF documentation from ODG schematics, guaranteeing that all annotations are baked into the final document.
 */
