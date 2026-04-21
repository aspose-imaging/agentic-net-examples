using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\thumbnail.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Get EXIF thumbnail (may be null)
            var thumbnail = jpegImage.ExifData?.Thumbnail;
            if (thumbnail == null)
            {
                Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                return;
            }

            // Save thumbnail as PNG
            using (thumbnail)
            {
                var pngOptions = new PngOptions();
                thumbnail.Save(outputPath, pngOptions);
            }
        }
    }
}