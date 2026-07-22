using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string zipPath = "thumbnails.zip";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure the directory for the zip file exists
            string zipDir = Path.GetDirectoryName(zipPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(zipDir) ? "." : zipDir);

            // Create or overwrite the zip archive
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Update))
            {
                // Process JPEG files
                string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
                string[] allFiles = new string[jpgFiles.Length + jpegFiles.Length];
                jpgFiles.CopyTo(allFiles, 0);
                jpegFiles.CopyTo(allFiles, jpgFiles.Length);

                foreach (string inputPath in allFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (Image image = Image.Load(inputPath))
                    {
                        // Create a thumbnail (100x100)
                        image.Resize(100, 100);

                        // Save thumbnail to memory stream as JPEG
                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions jpegOptions = new JpegOptions();
                            image.Save(ms, jpegOptions);
                            ms.Position = 0;

                            string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                            var entry = archive.CreateEntry(entryName);
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Thumbnails have been saved to {zipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑create 100×100 JPEG thumbnails for all images in a folder and deliver them as a single compressed ZIP file for a web gallery preview.
 * 2. When an e‑commerce platform must generate small preview images of product photos and package them for fast download by mobile clients.
 * 3. When a digital asset management system requires automated thumbnail extraction from a large collection of JPEG files and archiving the results for backup or transfer.
 * 4. When a content‑management workflow involves creating thumbnail versions of user‑uploaded JPEGs and bundling them for email attachment or reporting.
 * 5. When a desktop application must resize every JPEG in a directory to a thumbnail size and store the thumbnails in a ZIP archive for later batch processing or distribution.
 */