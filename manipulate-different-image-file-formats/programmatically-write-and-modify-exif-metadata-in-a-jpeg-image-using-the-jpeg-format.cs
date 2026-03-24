using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
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

        // Load JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data container
            var exif = jpegImage.ExifData;
            if (exif != null)
            {
                // Modify EXIF tags
                exif.Make = "MyCameraMaker";
                exif.Model = "MyCameraModel";
                exif.Artist = "John Doe";
                exif.Copyright = "© 2026 MyCompany";
                exif.ImageDescription = "Sample image with modified EXIF";
            }

            // Save the image with updated EXIF metadata
            jpegImage.Save(outputPath);
        }
    }
}