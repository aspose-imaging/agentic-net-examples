// HOW-TO: Batch Convert PNG Images to PDF and Zip Them in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing PNG files
            string inputDirectory = @"C:\InputPngs";
            // Hardcoded output ZIP file path
            string outputZipPath = @"C:\Output\images.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            // Shared memory stream used for each PDF conversion
            using (MemoryStream sharedPdfStream = new MemoryStream())
            // Create the ZIP archive
            using (FileStream zipFileStream = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
            {
                foreach (string pngPath in pngFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    // Load the PNG image
                    using (Image image = Image.Load(pngPath))
                    {
                        // Prepare PDF options (default compression)
                        PdfOptions pdfOptions = new PdfOptions();

                        // Reset shared stream for new PDF content
                        sharedPdfStream.SetLength(0);
                        sharedPdfStream.Position = 0;

                        // Save image as PDF into the shared memory stream
                        image.Save(sharedPdfStream, pdfOptions);
                        sharedPdfStream.Position = 0;

                        // Create a ZIP entry named after the original PNG file
                        string entryName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                        ZipArchiveEntry zipEntry = zipArchive.CreateEntry(entryName, CompressionLevel.Optimal);
                        using (Stream entryStream = zipEntry.Open())
                        {
                            // Copy PDF bytes from the shared stream into the ZIP entry
                            sharedPdfStream.CopyTo(entryStream);
                        }
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
 * 1. When you need to generate a single downloadable ZIP containing PDFs for a large set of PNG assets, such as product photos for an e‑commerce catalog.
 * 2. When an automated reporting tool must transform scanned PNG diagrams into PDF pages before archiving them for compliance.
 * 3. When a web service receives multiple PNG uploads and must return a compressed PDF bundle to the client without writing intermediate files to disk.
 * 4. When a desktop application wants to batch‑process user‑selected PNG files into PDFs while keeping memory usage low by reusing a single MemoryStream.
 * 5. When a CI/CD pipeline has to package documentation screenshots (PNG) as PDFs inside a ZIP for distribution to stakeholders.
 */
