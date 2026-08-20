// HOW-TO: Apply Alpha Blending To Images In A Zip And Save To New Zip In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output ZIP paths
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            // Validate input ZIP existence
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
                    // Skip directories
                    if (string.IsNullOrEmpty(entry.Name))
                        continue;

                    // Read entry into memory
                    using (var entryStream = entry.Open())
                    using (var memory = new MemoryStream())
                    {
                        entryStream.CopyTo(memory);
                        memory.Position = 0;

                        // Load image as RasterImage
                        using (RasterImage image = (RasterImage)Image.Load(memory))
                        {
                            // Apply alpha blending (50% opacity) using the image itself as overlay
                            image.Blend(new Aspose.Imaging.Point(0, 0), image, 128);

                            // Determine appropriate save options based on file extension
                            string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                            ImageOptionsBase options;
                            switch (ext)
                            {
                                case ".jpg":
                                case ".jpeg":
                                    options = new JpegOptions();
                                    break;
                                case ".png":
                                    options = new PngOptions();
                                    break;
                                case ".bmp":
                                    options = new BmpOptions();
                                    break;
                                case ".gif":
                                    options = new GifOptions();
                                    break;
                                case ".tif":
                                case ".tiff":
                                    options = new TiffOptions(TiffExpectedFormat.Default);
                                    break;
                                case ".webp":
                                    options = new WebPOptions();
                                    break;
                                default:
                                    // Fallback to JPEG for unsupported formats
                                    options = new JpegOptions();
                                    break;
                            }

                            // Create entry in output ZIP and save processed image
                            var outEntry = outputArchive.CreateEntry(entry.Name);
                            using (var outEntryStream = outEntry.Open())
                            {
                                image.Save(outEntryStream, options);
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
 * 1. When you need to batch‑process a collection of PNG, JPEG, or BMP files stored in a ZIP archive and apply a uniform transparency effect before distributing them.
 * 2. When an e‑commerce platform wants to add a semi‑transparent watermark to all product images packaged in a ZIP file without extracting them to disk.
 * 3. When a mobile app generates animated GIF frames in a ZIP and you must blend each frame with a background color before creating the final animation.
 * 4. When a digital asset management system must convert TIFF and WebP images from an uploaded ZIP, apply alpha blending, and re‑package them for downstream workflows.
 * 5. When a CI/CD pipeline needs to automatically read image assets from a source ZIP, apply opacity adjustments using Aspose.Imaging, and store the processed results in a new ZIP for deployment.
 */
