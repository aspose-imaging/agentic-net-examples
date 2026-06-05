using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string zipPath = "thumbnails.zip";

            // Ensure the directory for the zip file exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath) ?? ".");

            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Update))
            {
                var jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
                var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
                var allFiles = jpgFiles.Concat(jpegFiles).ToArray();

                foreach (var inputPath in allFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (RasterImage image = (RasterImage)Image.Load(inputPath))
                    {
                        int thumbWidth = 100;
                        int thumbHeight = 100;
                        image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                        string entryName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.jpg";
                        var entry = zip.CreateEntry(entryName, CompressionLevel.Optimal);
                        using (var entryStream = entry.Open())
                        {
                            JpegOptions jpegOptions = new JpegOptions
                            {
                                Quality = 80
                            };
                            image.Save(entryStream, jpegOptions);
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
 * 1. When a web application needs to generate 100 × 100 pixel JPEG thumbnails of user‑uploaded photos and deliver them as a single zip archive for easy download.
 * 2. When an e‑commerce site wants to create low‑resolution preview images for product photos stored in a folder, resize them with Aspose.Imaging, and bundle the thumbnails for batch upload.
 * 3. When a digital asset management system must produce thumbnail versions of JPEG documents for quick browsing and archive them in a zip file for efficient storage.
 * 4. When a photo‑sharing service has to process a batch of JPEG/JPEG images, resize each to a standard thumbnail size using C# and Aspose.Imaging, and provide the results as a compressed zip to clients.
 * 5. When a desktop utility is required to scan a directory of JPEG images, generate thumbnails, and package them into a zip archive for backup or distribution.
 */