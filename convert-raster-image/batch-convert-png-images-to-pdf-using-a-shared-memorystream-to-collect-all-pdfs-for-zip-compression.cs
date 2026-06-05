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

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all PNG files in the input directory (non‑recursive)
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");
            if (pngFiles.Length == 0)
            {
                Console.Error.WriteLine("No PNG files found to process.");
                return;
            }

            // Shared memory stream that will hold the ZIP archive
            using (MemoryStream zipMemoryStream = new MemoryStream())
            {
                // Create a ZIP archive in the shared memory stream
                using (ZipArchive zipArchive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (string pngPath in pngFiles)
                    {
                        // Verify each PNG file exists before processing
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

                                // Create a ZIP entry for this PDF
                                string pdfFileName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                                ZipArchiveEntry entry = zipArchive.CreateEntry(pdfFileName, CompressionLevel.Optimal);
                                using (Stream entryStream = entry.Open())
                                {
                                    pdfStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }

                // Write the ZIP archive from memory to the output file
                // Ensure the output directory exists (already called above)
                using (FileStream fileStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
                {
                    zipMemoryStream.Position = 0;
                    zipMemoryStream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}