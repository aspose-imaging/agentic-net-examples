using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\thumbnail.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Retrieve the thumbnail from EXIF data
            RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;

            if (thumbnail == null)
            {
                Console.Error.WriteLine("No thumbnail found in EXIF data.");
                return;
            }

            // Save the thumbnail as a separate JPEG file
            var saveOptions = new JpegOptions();
            thumbnail.Save(outputPath, saveOptions);
        }
    }
}