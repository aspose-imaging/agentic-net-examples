using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input directory containing PNG files
        string inputDirectory = @"C:\Images\Input";

        // Hardcoded output ZIP file path
        string outputZipPath = @"C:\Images\Output\ConvertedPdfs.zip";

        // Verify input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Directory not found: {inputDirectory}");
            return;
        }

        // Ensure the output directory exists (unconditional per rules)
        Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

        // Gather all PNG files in the input directory
        string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

        // Shared memory stream that will hold the ZIP archive
        using (MemoryStream zipStream = new MemoryStream())
        {
            using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (string pngPath in pngFiles)
                {
                    // Check each input file existence (rule enforced)
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        return;
                    }

                    // Load PNG image using Aspose.Imaging
                    using (Image image = Image.Load(pngPath))
                    {
                        // Prepare PDF export options
                        PdfOptions pdfOptions = new PdfOptions();

                        // Save the image to a temporary memory stream as PDF
                        using (MemoryStream pdfStream = new MemoryStream())
                        {
                            image.Save(pdfStream, pdfOptions);
                            pdfStream.Position = 0; // Reset for reading

                            // Create an entry in the ZIP archive for this PDF
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

            // Write the ZIP archive to the output file
            using (FileStream fileStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
            {
                zipStream.Position = 0;
                zipStream.CopyTo(fileStream);
            }
        }
    }
}