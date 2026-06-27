using System;
using System.IO;
using System.IO.Compression;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing JPEG images
            string inputDirectory = @"C:\Images\Input";

            // Hardcoded output zip file path for thumbnails
            string outputZipPath = @"C:\Images\Thumbnails\thumbnails.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create (or overwrite) the zip archive
            using (ZipArchive zip = ZipFile.Open(outputZipPath, ZipArchiveMode.Create))
            {
                // Get all JPEG files (case‑insensitive)
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
                string[] jpegFilesUpper = Directory.GetFiles(inputDirectory, "*.jpeg");
                string[] allFiles = new string[jpegFiles.Length + jpegFilesUpper.Length];
                jpegFiles.CopyTo(allFiles, 0);
                jpegFilesUpper.CopyTo(allFiles, jpegFiles.Length);

                foreach (string filePath in allFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Load the JPEG image
                    using (JpegImage image = (JpegImage)Image.Load(filePath))
                    {
                        // Determine thumbnail size while preserving aspect ratio (max 100x100)
                        const int maxThumbSize = 100;
                        int thumbWidth = image.Width;
                        int thumbHeight = image.Height;

                        if (thumbWidth > thumbHeight)
                        {
                            if (thumbWidth > maxThumbSize)
                            {
                                thumbHeight = thumbHeight * maxThumbSize / thumbWidth;
                                thumbWidth = maxThumbSize;
                            }
                        }
                        else
                        {
                            if (thumbHeight > maxThumbSize)
                            {
                                thumbWidth = thumbWidth * maxThumbSize / thumbHeight;
                                thumbHeight = maxThumbSize;
                            }
                        }

                        // Resize to thumbnail dimensions
                        image.Resize(thumbWidth, thumbHeight);

                        // Save thumbnail to a memory stream (PNG format)
                        using (MemoryStream thumbStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions();
                            image.Save(thumbStream, pngOptions);
                            thumbStream.Position = 0;

                            // Add thumbnail to zip archive
                            string entryName = Path.GetFileNameWithoutExtension(filePath) + "_thumb.png";
                            ZipArchiveEntry entry = zip.CreateEntry(entryName);
                            using (Stream entryStream = entry.Open())
                            {
                                thumbStream.CopyTo(entryStream);
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
 * 1. When a developer needs to create 100 × 100 pixel JPEG thumbnails for every image in a server directory and deliver them as a single zip file for batch download.
 * 2. When an e‑commerce platform must automatically generate small preview images of product photos stored as JPEGs and archive them for offline catalog generation.
 * 3. When a desktop utility has to compress a collection of user‑uploaded JPEG pictures into a zip bundle of thumbnails to reduce bandwidth before sending them to a mobile client.
 * 4. When a content‑management system requires periodic processing of a folder of JPEG assets to produce uniform thumbnail sizes and store them in a zip for backup or migration.
 * 5. When a photo‑sharing website wants to provide a one‑click “download all thumbnails” feature by resizing each JPEG to a max of 100 px and packaging the results into a zip archive.
 */