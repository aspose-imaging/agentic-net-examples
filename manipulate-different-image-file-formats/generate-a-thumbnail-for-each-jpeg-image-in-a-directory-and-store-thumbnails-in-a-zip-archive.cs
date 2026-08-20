// HOW-TO: Create JPEG Thumbnails and Save Them to a Zip File in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputDirectory = "Input";
            string outputZipPath = "Output/thumbnails.zip";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists (unconditional as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create the zip archive
            using (var zipStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.Write))
            using (var zip = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create, false))
            {
                // Process each JPEG file in the input directory
                foreach (var filePath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
                    // Validate file existence
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Load the image
                    using (Image image = Image.Load(filePath))
                    {
                        // Create a thumbnail (100x100)
                        int thumbWidth = 100;
                        int thumbHeight = 100;
                        image.Resize(thumbWidth, thumbHeight);

                        // Save thumbnail to a memory stream using JPEG options
                        using (var ms = new MemoryStream())
                        {
                            var jpegOptions = new JpegOptions
                            {
                                Quality = 90
                            };
                            image.Save(ms, jpegOptions);
                            ms.Position = 0;

                            // Add the thumbnail to the zip archive
                            string entryName = Path.GetFileNameWithoutExtension(filePath) + "_thumb.jpg";
                            var entry = zip.CreateEntry(entryName);
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Thumbnails have been saved to {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate small preview images for a large collection of JPEG photos and deliver them as a single downloadable package.
 * 2. When an e‑commerce site wants to create product thumbnail galleries from high‑resolution JPEGs and bundle them for offline distribution.
 * 3. When a desktop application must batch‑process user‑uploaded JPEGs, resize them to 100 × 100 pixels, and archive the results for backup.
 * 4. When a digital asset management system requires automated thumbnail creation and storage in a ZIP file to reduce storage overhead.
 * 5. When a reporting tool has to embed compact JPEG previews of charts into a compressed archive for email attachment.
 */
