using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output ZIP paths
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Open input ZIP for reading
            using (FileStream inputZipStream = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
            using (var inputArchive = new System.IO.Compression.ZipArchive(inputZipStream, System.IO.Compression.ZipArchiveMode.Read))
            // Create output ZIP for writing
            using (FileStream outputZipStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
            using (var outputArchive = new System.IO.Compression.ZipArchive(outputZipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (var entry in inputArchive.Entries)
                {
                    // Process only image files based on extension
                    string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".gif" && ext != ".tif" && ext != ".tiff")
                        continue;

                    using (Stream entryStream = entry.Open())
                    using (RasterImage sourceImage = (RasterImage)Image.Load(entryStream))
                    {
                        // Create a blank canvas with the same dimensions
                        using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), sourceImage.Width, sourceImage.Height))
                        {
                            // Apply alpha blending (50% opacity)
                            canvas.Blend(new Aspose.Imaging.Point(0, 0), sourceImage, 128);

                            // Save blended image to a memory stream
                            using (MemoryStream ms = new MemoryStream())
                            {
                                canvas.Save(ms, new PngOptions());
                                ms.Position = 0;

                                // Add the blended image to the output ZIP
                                var outEntry = outputArchive.CreateEntry(entry.Name, System.IO.Compression.CompressionLevel.Optimal);
                                using (Stream outStream = outEntry.Open())
                                {
                                    ms.CopyTo(outStream);
                                }
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
 * 1. When a developer needs to batch‑process a collection of product photos stored in a ZIP file, apply a semi‑transparent watermark via alpha blending, and deliver the watermarked images back to the client as a new ZIP archive.
 * 2. When an e‑learning platform must extract user‑uploaded slide images from a compressed package, blend each slide with a corporate branding overlay, and repack the branded slides for distribution.
 * 3. When a digital asset management system has to convert a batch of scanned TIFF and BMP files inside an archive into PNGs with a uniform opacity mask before archiving them for long‑term storage.
 * 4. When a marketing automation tool has to read a ZIP of campaign graphics, apply a fade‑out effect using alpha blending to match a theme, and generate a new ZIP for upload to a content delivery network.
 * 5. When a photo‑editing web service wants to accept a ZIP of images, programmatically blend each image with a background layer to create composite pictures, and return the composites in a downloadable ZIP file.
 */