// HOW-TO: Add Red Thumbnail to JPEG JFIF and EXIF Segments in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

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
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a thumbnail raster image (100x100) using PNG options
                PngOptions thumbOptions = new PngOptions();
                using (RasterImage thumbnail = (RasterImage)Image.Create(thumbOptions, 100, 100))
                {
                    // Fill the thumbnail with a solid red color
                    Graphics graphics = new Graphics(thumbnail);
                    SolidBrush brush = new SolidBrush(Color.Red);
                    graphics.FillRectangle(brush, thumbnail.Bounds);

                    // Ensure JFIF segment exists and assign the thumbnail
                    if (jpegImage.Jfif == null)
                    {
                        jpegImage.Jfif = new JFIFData();
                    }
                    jpegImage.Jfif.Thumbnail = thumbnail;

                    // Assign the same thumbnail to the EXIF segment
                    jpegImage.ExifData.Thumbnail = thumbnail;

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
 * 1. When you need to embed a custom preview image into a JPEG’s JFIF and EXIF metadata for faster thumbnail display in photo management software.
 * 2. When generating a red placeholder thumbnail for newly uploaded JPEGs before the actual image is processed, ensuring both JFIF and EXIF sections contain the same preview.
 * 3. When creating a batch script that adds consistent thumbnails to legacy JPEG files so that mobile devices and web galleries can read the thumbnail from either metadata segment.
 * 4. When building a C# application that must comply with cameras that read thumbnails from the EXIF block while other tools expect them in the JFIF block.
 * 5. When testing image‑processing pipelines by programmatically inserting a known thumbnail into a JPEG to verify that downstream tools correctly extract metadata from both JFIF and EXIF sections.
 */
