// HOW-TO: Create JPEG Thumbnails and Zip Them Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputZipPath = "thumbnails.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath) ?? ".");

            var files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            using (FileStream zipToOpen = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                foreach (var filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (Image image = Image.Load(filePath))
                    {
                        image.Resize(100, 100);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions options = new JpegOptions();
                            image.Save(ms, options);
                            ms.Position = 0;
                            string entryName = Path.GetFileNameWithoutExtension(filePath) + "_thumb.jpg";
                            ZipArchiveEntry entry = archive.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
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
 * 1. When you need to generate 100 × 100 JPEG thumbnails for a photo gallery and bundle them into a single zip file for easy download.
 * 2. When an e‑commerce platform must create product thumbnail images on the server and provide the thumbnails as a zipped package to third‑party vendors.
 * 3. When a desktop utility processes user‑uploaded JPEGs, resizes each to a thumbnail, and saves the thumbnails in a zip archive for offline backup.
 * 4. When a scheduled batch job has to compress a large set of JPEG files into small preview images and package them for email distribution.
 * 5. When a content‑management system wants to archive low‑resolution previews of original JPEG assets without modifying the source files.
 */
