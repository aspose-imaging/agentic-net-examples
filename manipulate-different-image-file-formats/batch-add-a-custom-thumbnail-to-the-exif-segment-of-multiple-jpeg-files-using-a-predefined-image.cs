// HOW-TO: Add Custom EXIF Thumbnail to Multiple JPEGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string thumbnailPath = "thumbnail.jpg";

            // Verify thumbnail exists
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            // Load thumbnail once
            using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
            {
                // Get all JPEG files in the input directory
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

                foreach (string inputPath in jpegFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Prepare output path and ensure its directory exists
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load JPEG image
                    using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                    {
                        // Ensure ExifData is instantiated
                        if (jpeg.ExifData == null)
                        {
                            jpeg.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                        }

                        // Assign the custom thumbnail
                        jpeg.ExifData.Thumbnail = thumbnail;

                        // Save the modified JPEG
                        jpeg.Save(outputPath);
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
 * 1. When you need to embed a company logo as a thumbnail in a batch of product photos for consistent preview in file explorers.
 * 2. When preparing a large collection of images for a digital asset management system that requires each JPEG to contain a custom thumbnail for faster browsing.
 * 3. When automating the creation of photo archives where each picture must include a specific watermark thumbnail in its EXIF data for branding purposes.
 * 4. When migrating legacy JPEG files to a new workflow and you must add a standardized thumbnail to all images to ensure compatibility with older photo viewers.
 * 5. When generating a set of images for an e‑commerce site and you want to programmatically attach a promotional thumbnail to each JPEG to improve thumbnail previews on the website.
 */
