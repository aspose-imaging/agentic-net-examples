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

            // MemoryStream that will hold the ZIP archive
            using (MemoryStream zipStream = new MemoryStream())
            {
                // Create a ZIP archive in the MemoryStream
                using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    // Enumerate all PNG files in the input directory
                    foreach (string pngPath in Directory.GetFiles(inputDirectory, "*.png"))
                    {
                        // Verify the PNG file exists
                        if (!File.Exists(pngPath))
                        {
                            Console.Error.WriteLine($"File not found: {pngPath}");
                            return;
                        }

                        // Load the PNG image
                        using (Image image = Image.Load(pngPath))
                        {
                            // Prepare PDF export options (default options are sufficient)
                            PdfOptions pdfOptions = new PdfOptions();

                            // Save the image as PDF into a temporary MemoryStream
                            using (MemoryStream pdfStream = new MemoryStream())
                            {
                                image.Save(pdfStream, pdfOptions);
                                pdfStream.Position = 0; // Reset stream position for reading

                                // Create a ZIP entry for this PDF
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

                // Write the completed ZIP archive to the output file
                Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));
                using (FileStream fileStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
                {
                    zipStream.Position = 0;
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