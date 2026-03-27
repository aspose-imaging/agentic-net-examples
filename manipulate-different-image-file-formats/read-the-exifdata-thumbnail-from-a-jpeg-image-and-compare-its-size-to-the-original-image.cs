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
        string inputPath = "input.jpg";
        string outputPath = "thumbnail_output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (even if we later decide not to save)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Original image dimensions
            int originalWidth = jpegImage.Width;
            int originalHeight = jpegImage.Height;

            // Access EXIF data
            JpegExifData jpegExifData = jpegImage.ExifData as JpegExifData;
            if (jpegExifData == null)
            {
                Console.WriteLine("No EXIF data found in the image.");
                return;
            }

            // Get the thumbnail (may be null)
            RasterImage thumbnail = jpegExifData.Thumbnail;
            if (thumbnail == null)
            {
                Console.WriteLine("No thumbnail present in EXIF data.");
                return;
            }

            // Thumbnail dimensions
            int thumbWidth = thumbnail.Width;
            int thumbHeight = thumbnail.Height;

            // Output comparison
            Console.WriteLine($"Original image size:  {originalWidth}x{originalHeight}");
            Console.WriteLine($"Thumbnail size:       {thumbWidth}x{thumbHeight}");

            // Optionally save the thumbnail to a file
            // Ensure the directory exists (already done above)
            thumbnail.Save(outputPath);
            Console.WriteLine($"Thumbnail saved to: {outputPath}");
        }
    }
}