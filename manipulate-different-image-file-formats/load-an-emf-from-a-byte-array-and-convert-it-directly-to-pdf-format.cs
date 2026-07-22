using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read EMF file into a byte array
            byte[] emfData = File.ReadAllBytes(inputPath);

            // Load EMF from the byte array
            using (MemoryStream ms = new MemoryStream(emfData))
            {
                using (Image image = Image.Load(ms))
                {
                    // Save directly to PDF format
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
 * 1. When a desktop application needs to convert user‑uploaded EMF vector graphics stored in a database as a byte array into PDF reports for printing or archiving.
 * 2. When an automated document pipeline must read EMF files from a network share, load them from memory, and generate PDF versions without creating intermediate files on disk.
 * 3. When a web service receives EMF data via an API request, loads it from a byte array, and returns a PDF stream to the client for preview in browsers.
 * 4. When a batch job processes a large collection of EMF assets, loading each file into a MemoryStream and saving directly to PDF to reduce I/O overhead and improve performance.
 * 5. When a legacy Windows application exports charts as EMF and a modern .NET component needs to transform those byte‑array images into PDF for cross‑platform distribution.
 */