using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.jpg";
        string thumbnailOutputPath = "thumbnail_output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Original image dimensions
            int originalWidth = jpegImage.Width;
            int originalHeight = jpegImage.Height;
            Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");

            // Access EXIF thumbnail
            JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
            if (jpegExif == null || jpegExif.Thumbnail == null)
            {
                Console.WriteLine("No EXIF thumbnail found in the image.");
                return;
            }

            // Thumbnail dimensions
            RasterImage thumbnail = jpegExif.Thumbnail;
            int thumbWidth = thumbnail.Width;
            int thumbHeight = thumbnail.Height;
            Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

            // Compare dimensions
            if (originalWidth == thumbWidth && originalHeight == thumbHeight)
            {
                Console.WriteLine("Thumbnail dimensions match the original image.");
            }
            else
            {
                Console.WriteLine("Thumbnail dimensions differ from the original image.");
            }

            // Save thumbnail to file (demonstrates output path handling)
            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailOutputPath) ?? ".");
            thumbnail.Save(thumbnailOutputPath);
            Console.WriteLine($"Thumbnail saved to: {thumbnailOutputPath}");
        }
    }
}