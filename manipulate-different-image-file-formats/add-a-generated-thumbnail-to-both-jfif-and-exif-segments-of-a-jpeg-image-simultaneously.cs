using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a thumbnail raster image (e.g., 100x100 blue square)
                int thumbWidth = 100;
                int thumbHeight = 100;
                PngOptions thumbOptions = new PngOptions();
                using (RasterImage thumb = (RasterImage)Image.Create(thumbOptions, thumbWidth, thumbHeight))
                {
                    // Fill thumbnail with a solid color
                    Graphics graphics = new Graphics(thumb);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    // Assign thumbnail to EXIF segment
                    if (jpegImage.ExifData == null)
                    {
                        jpegImage.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                    }
                    jpegImage.ExifData.Thumbnail = thumb;

                    // Assign thumbnail to JFIF segment
                    if (jpegImage.Jfif == null)
                    {
                        jpegImage.Jfif = new JFIFData();
                    }
                    jpegImage.Jfif.Thumbnail = thumb;

                    // Save the modified JPEG image
                    jpegImage.Save(outputPath);
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
 * 1. When a developer needs to embed a preview thumbnail in both the EXIF and JFIF sections of a JPEG so that photo management software and web browsers can display a small preview without loading the full image.
 * 2. When creating a digital asset pipeline that generates consistent 100x100 blue placeholder thumbnails for newly uploaded JPEGs to improve catalog browsing performance.
 * 3. When implementing a C# application that must ensure compatibility with legacy devices that read thumbnails from the JFIF segment while modern tools read from the EXIF segment.
 * 4. When automating the preparation of JPEG images for e‑commerce platforms that require embedded thumbnails for quick product image previews in search results.
 * 5. When building a photo‑sharing service that adds a solid‑color thumbnail to user‑uploaded JPEGs to comply with metadata standards for mobile galleries and cloud storage indexing.
 */