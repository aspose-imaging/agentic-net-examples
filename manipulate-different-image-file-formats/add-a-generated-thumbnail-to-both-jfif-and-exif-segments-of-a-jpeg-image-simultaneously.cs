using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                using (JpegImage thumb = new JpegImage(100, 100))
                {
                    // Fill thumbnail with a solid color
                    Graphics graphics = new Graphics(thumb);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    // Assign thumbnail to JFIF segment
                    jpegImage.Jfif = new JFIFData();
                    jpegImage.Jfif.Thumbnail = thumb;

                    // Ensure EXIF data container exists and assign thumbnail
                    if (jpegImage.ExifData == null)
                    {
                        jpegImage.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                    }
                    jpegImage.ExifData.Thumbnail = thumb;

                    // Save the modified image
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
 * 1. When a developer needs to embed a preview image in a JPEG so that both web browsers (reading the JFIF thumbnail) and photo‑management software (reading the EXIF thumbnail) can display a quick thumbnail without loading the full‑resolution file.
 * 2. When building a digital asset management system that must generate consistent low‑resolution previews for uploaded photos and store them in both the JFIF and EXIF sections to maximize compatibility across different operating systems and image viewers.
 * 3. When creating a batch‑processing tool that adds a solid‑color placeholder thumbnail to legacy JPEG files that lack any thumbnail data, ensuring older cameras and modern editors can both show a preview.
 * 4. When developing a C# application that automatically generates a 100 × 100 pixel thumbnail for user‑uploaded images and embeds it in the JPEG’s metadata so that email clients and social media platforms can render the thumbnail instantly.
 * 5. When implementing a photo‑sharing API that must supply a JPEG with embedded thumbnails in both JFIF and EXIF segments to satisfy client devices that read either metadata format for faster image loading on mobile networks.
 */