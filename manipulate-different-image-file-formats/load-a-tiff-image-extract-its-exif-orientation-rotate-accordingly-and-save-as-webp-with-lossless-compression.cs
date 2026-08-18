// HOW-TO: Convert TIFF to Lossless WebP with EXIF Orientation Correction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load TIFF image
            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Extract EXIF orientation if present
                var exif = tiff.ExifData;
                if (exif != null)
                {
                    int? orientation = null;
                    try
                    {
                        orientation = (int)exif.GetType().GetProperty("Orientation")?.GetValue(exif);
                    }
                    catch { /* ignore if property not accessible */ }

                    if (orientation.HasValue)
                    {
                        // Apply rotation based on EXIF orientation
                        switch (orientation.Value)
                        {
                            case 6: // Rotate 90 CW
                                tiff.RotateFlip(Aspose.Imaging.RotateFlipType.Rotate90FlipNone);
                                break;
                            case 3: // Rotate 180
                                tiff.RotateFlip(Aspose.Imaging.RotateFlipType.Rotate180FlipNone);
                                break;
                            case 8: // Rotate 270 CW
                                tiff.RotateFlip(Aspose.Imaging.RotateFlipType.Rotate270FlipNone);
                                break;
                            default:
                                // No rotation needed
                                break;
                        }
                    }
                }

                // Prepare WebP options for lossless compression
                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = true,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save as WebP
                tiff.Save(outputPath, webpOptions);
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
 * 1. When you need to display scanned documents on the web and must correct camera rotation stored in EXIF before converting them to compact lossless WebP files.
 * 2. When a photo‑processing pipeline receives TIFF images from mobile devices and requires automatic orientation fixing and conversion to WebP to reduce bandwidth.
 * 3. When an e‑commerce site stores product images as TIFF and wants to generate lossless WebP thumbnails that respect the original orientation metadata.
 * 4. When a digital archiving system must preserve the exact visual appearance of TIFF scans while providing fast‑loading WebP versions for browsers.
 * 5. When a C# application integrates Aspose.Imaging to batch‑process TIFF files, applying EXIF‑based rotation and saving them as lossless WebP for cross‑platform compatibility.
 */
