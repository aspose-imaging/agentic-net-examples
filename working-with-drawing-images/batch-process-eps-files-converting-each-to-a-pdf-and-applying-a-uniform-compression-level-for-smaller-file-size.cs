using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputEps";
            string outputDirectory = @"C:\OutputPdf";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all EPS files in the input directory
            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path (same file name with .pdf extension)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (var image = (EpsImage)Image.Load(inputPath))
                {
                    // Configure PDF options with uniform compression
                    var pdfOptions = new PdfOptions
                    {
                        PdfCoreOptions = new PdfCoreOptions
                        {
                            Compression = PdfImageCompressionOptions.Flate // Uniform compression for smaller size
                        }
                    };

                    // Save as PDF
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
 * 1. When a graphic design studio must convert dozens of EPS logo files into PDF portfolios while applying uniform Flate compression to reduce download size.
 * 2. When an engineering firm needs to automate the transformation of EPS schematics into compressed PDFs for inclusion in digital manuals.
 * 3. When a marketing department wants to batch‑process EPS advertisements into PDF format for email campaigns, ensuring each PDF is optimally compressed for faster delivery.
 * 4. When a legal office requires a script to turn EPS evidence images into PDF documents with consistent compression to meet file‑size limits for electronic filing.
 * 5. When a cloud‑based document management system must ingest a folder of EPS assets and store them as compressed PDFs for archival and quick preview.
 */