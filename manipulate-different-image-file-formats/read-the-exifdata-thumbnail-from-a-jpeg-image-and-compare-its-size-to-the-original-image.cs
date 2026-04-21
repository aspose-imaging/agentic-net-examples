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
        string inputPath = @"C:\Images\sample.jpg";
        string thumbnailPath = @"C:\Images\sample_thumbnail.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists before saving
        Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));

        // Load the JPEG image
        using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
        {
            // Original image dimensions
            int originalWidth = jpeg.Width;
            int originalHeight = jpeg.Height;

            // Retrieve the EXIF thumbnail (may be null)
            RasterImage thumbnail = jpeg.ExifData?.Thumbnail;

            if (thumbnail == null)
            {
                Console.WriteLine("No EXIF thumbnail present in the image.");
                return;
            }

            // Save the thumbnail to a file for size comparison
            thumbnail.Save(thumbnailPath);

            // Thumbnail dimensions
            int thumbWidth = thumbnail.Width;
            int thumbHeight = thumbnail.Height;

            // File sizes in bytes
            long originalFileSize = new FileInfo(inputPath).Length;
            long thumbnailFileSize = new FileInfo(thumbnailPath).Length;

            // Output comparison results
            Console.WriteLine($"Original image: {originalWidth}x{originalHeight}, {originalFileSize} bytes");
            Console.WriteLine($"Thumbnail image: {thumbWidth}x{thumbHeight}, {thumbnailFileSize} bytes");
        }
    }
}