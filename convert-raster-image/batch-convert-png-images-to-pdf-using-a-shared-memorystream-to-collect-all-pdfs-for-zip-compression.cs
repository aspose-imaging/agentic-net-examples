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
            string inputDirectory = @"C:\Images\Input";

            // Hardcoded output ZIP file path
            string outputZipPath = @"C:\Images\Output\converted.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Verify the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            // Shared memory stream that will hold the ZIP archive
            using (MemoryStream zipStream = new MemoryStream())
            {
                // Create a ZIP archive in the memory stream
                using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    foreach (string pngPath in pngFiles)
                    {
                        // Verify each input file exists
                        if (!File.Exists(pngPath))
                        {
                            Console.Error.WriteLine($"File not found: {pngPath}");
                            return;
                        }

                        // Load the PNG image
                        using (Image image = Image.Load(pngPath))
                        {
                            // Prepare PDF export options (default compression)
                            PdfOptions pdfOptions = new PdfOptions();

                            // Save the image as PDF into a temporary memory stream
                            using (MemoryStream pdfStream = new MemoryStream())
                            {
                                image.Save(pdfStream, pdfOptions);
                                pdfStream.Position = 0; // Reset for reading

                                // Create a ZIP entry named after the original file but with .pdf extension
                                string entryName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                                ZipArchiveEntry entry = zipArchive.CreateEntry(entryName, CompressionLevel.Optimal);

                                // Write the PDF bytes into the ZIP entry
                                using (Stream entryStream = entry.Open())
                                {
                                    pdfStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }

                // Write the ZIP archive from memory to the output file
                zipStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
                {
                    zipStream.CopyTo(fileStream);
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
 * 1. When a web application needs to let users upload multiple PNG screenshots and receive a single downloadable PDF archive, a developer can use this code to convert each PNG to PDF in memory and zip them for fast delivery.
 * 2. When an automated reporting system generates chart images as PNG files nightly and must bundle them into a PDF portfolio for compliance auditors, this snippet enables batch conversion and compression without writing intermediate files to disk.
 * 3. When a desktop utility must archive scanned PNG documents into a searchable PDF collection for archival storage, the shared MemoryStream approach reduces I/O overhead while creating a zip file for easy transport.
 * 4. When a cloud function processes user‑submitted PNG assets and needs to return a single compressed package of PDFs to a mobile client, the code demonstrates how to perform the conversion and zip creation entirely in memory using Aspose.Imaging for .NET.
 * 5. When a CI/CD pipeline validates that generated PNG assets can be correctly rendered as PDFs and packaged for distribution, this example provides a quick way to batch convert and zip the results as part of automated testing.
 */