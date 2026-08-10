// HOW-TO: Read JPEG EXIF Thumbnail and Compare Its Size to Original Image in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "thumbnail.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif?.Thumbnail != null)
                {
                    // Thumbnail is a RasterImage
                    using (RasterImage thumb = (RasterImage)exif.Thumbnail)
                    {
                        Console.WriteLine($"Original size: {image.Width}x{image.Height}");
                        Console.WriteLine($"Thumbnail size: {thumb.Width}x{thumb.Height}");

                        // Save the thumbnail to a separate file
                        image.Save(outputPath, new JpegOptions());
                    }
                }
                else
                {
                    Console.WriteLine("No thumbnail present in EXIF data.");
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
 * 1. When you need to extract the embedded EXIF thumbnail from a JPEG to display a low‑resolution preview without loading the full‑size image.
 * 2. When you want to verify that a camera‑generated thumbnail is smaller than the original photo before creating a separate thumbnail file.
 * 3. When building a photo‑gallery application that lists image dimensions and needs to show both the original and its EXIF thumbnail sizes for performance analysis.
 * 4. When automating batch processing to save embedded thumbnails as separate JPEG files for archival or quick‑view purposes.
 * 5. When debugging image metadata issues and you must compare the dimensions of the EXIF thumbnail against the main image to ensure correct orientation and scaling.
 */
