using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.jpg";
            string outputPath = "thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (var jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Get thumbnail from EXIF data
                var thumb = jpegImage.ExifData?.Thumbnail;
                if (thumb == null)
                {
                    Console.Error.WriteLine("No thumbnail found in EXIF data.");
                    return;
                }

                // Save the thumbnail as a separate file
                using (thumb)
                {
                    thumb.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}