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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
            {
                // Generate a thumbnail (100x100) from the same source image
                using (RasterImage thumb = (RasterImage)Image.Load(inputPath))
                {
                    thumb.Resize(100, 100);

                    // Assign thumbnail to EXIF segment
                    jpeg.ExifData.Thumbnail = thumb;

                    // Assign thumbnail to JFIF segment
                    jpeg.Jfif = new JFIFData();
                    jpeg.Jfif.Thumbnail = thumb;
                }

                // Save the modified JPEG with both thumbnails
                jpeg.Save(outputPath);
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
 * 1. When a developer needs to embed a preview thumbnail in both the EXIF and JFIF segments of a JPEG so that photo management software and web browsers can display a quick preview without loading the full image.
 * 2. When building a digital asset management system that must preserve compatibility with legacy devices that read EXIF thumbnails while also supporting modern viewers that rely on JFIF thumbnails.
 * 3. When creating an automated pipeline that generates consistent 100 × 100 pixel thumbnails for uploaded JPEGs and stores them in both metadata sections to improve indexing speed in search engines.
 * 4. When implementing a C# application that processes user‑generated photos and needs to ensure the thumbnail appears in the image’s metadata for both mobile gallery apps (EXIF) and desktop image editors (JFIF).
 * 5. When migrating a large collection of JPEG files and wanting to add a generated thumbnail to each file’s EXIF and JFIF segments in a single pass using Aspose.Imaging for .NET.
 */