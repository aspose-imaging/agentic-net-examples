using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = "Output/thumbnail.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Retrieve the thumbnail from EXIF data
            RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;
            if (thumbnail == null)
            {
                Console.WriteLine("No thumbnail found in EXIF data.");
                return;
            }

            // Save the thumbnail as a separate JPEG file
            using (thumbnail)
            {
                JpegOptions saveOptions = new JpegOptions();
                thumbnail.Save(outputPath, saveOptions);
            }
        }
    }
}