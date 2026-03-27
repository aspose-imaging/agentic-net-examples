using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string thumbnailPath = @"C:\thumbnails\thumb.png";
        string inputDirectory = @"C:\images\input";
        string outputDirectory = @"C:\images\output";

        // Ensure thumbnail exists
        if (!File.Exists(thumbnailPath))
        {
            Console.Error.WriteLine($"File not found: {thumbnailPath}");
            return;
        }

        // Load the custom thumbnail once
        using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
        {
            // Get all JPEG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            foreach (string inputPath in inputFiles)
            {
                // Verify input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_with_thumb.jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG image
                using (JpegImage jpeg = new JpegImage(inputPath))
                {
                    // Ensure ExifData container exists
                    if (jpeg.ExifData == null)
                    {
                        jpeg.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                    }

                    // Assign the custom thumbnail
                    jpeg.ExifData.Thumbnail = thumbnail;

                    // Save the modified image
                    jpeg.Save(outputPath);
                }
            }
        }
    }
}