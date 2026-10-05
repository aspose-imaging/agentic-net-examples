// HOW-TO: Batch Convert PNG Images to PDF and Zip with MemoryStream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchPngToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string inputFolder = @"C:\Images\InputPngs";
                string outputFolder = @"C:\Images\OutputPdfs";
                string zipFilePath = @"C:\Images\ConvertedPdfs.zip";

                // Ensure output directories exist
                Directory.CreateDirectory(outputFolder);
                Directory.CreateDirectory(Path.GetDirectoryName(zipFilePath));

                // Prepare a shared MemoryStream for the zip archive
                using (MemoryStream zipStream = new MemoryStream())
                {
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                    {
                        // Process each PNG file in the input folder
                        foreach (string pngPath in Directory.GetFiles(inputFolder, "*.png"))
                        {
                            if (!File.Exists(pngPath))
                            {
                                Console.Error.WriteLine($"File not found: {pngPath}");
                                continue;
                            }

                            string pdfFileName = Path.GetFileNameWithoutExtension(pngPath) + ".pdf";
                            string pdfPath = Path.Combine(outputFolder, pdfFileName);

                            // Ensure the directory for the PDF exists
                            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                            // Load PNG and convert to PDF in memory
                            using (Image image = Image.Load(pngPath))
                            {
                                using (MemoryStream pdfStream = new MemoryStream())
                                {
                                    PdfOptions pdfOptions = new PdfOptions();
                                    image.Save(pdfStream, pdfOptions);
                                    pdfStream.Position = 0;

                                    // Save PDF to disk
                                    File.WriteAllBytes(pdfPath, pdfStream.ToArray());

                                    // Add PDF to zip archive
                                    ZipArchiveEntry entry = archive.CreateEntry(pdfFileName);
                                    using (Stream entryStream = entry.Open())
                                    {
                                        pdfStream.CopyTo(entryStream);
                                    }
                                }
                            }
                        }
                    }

                    // Write the zip archive to the final file
                    zipStream.Position = 0;
                    File.WriteAllBytes(zipFilePath, zipStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate PDF versions of a large set of PNG files for archival or reporting purposes.
 * 2. When you want to package the converted PDFs into a single ZIP file for easy download or transfer.
 * 3. When you must perform the conversion and compression entirely in memory to avoid creating temporary files on disk.
 * 4. When you are building a server‑side service that processes user‑uploaded PNGs and returns a compressed PDF bundle.
 * 5. When you need to automate the conversion of product screenshots or scanned documents into PDFs for compliance or distribution.
 */
