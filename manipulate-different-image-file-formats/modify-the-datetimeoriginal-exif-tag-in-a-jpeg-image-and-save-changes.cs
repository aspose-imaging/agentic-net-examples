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
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access JPEG EXIF data
            JpegExifData jpegExif = image.ExifData as JpegExifData;
            if (jpegExif != null)
            {
                // Modify the DateTimeOriginal tag (format: "yyyy:MM:dd HH:mm:ss")
                jpegExif.DateTimeOriginal = "2023:01:01 12:00:00";
            }

            // Save the modified image
            image.Save(outputPath);
        }
    }
}