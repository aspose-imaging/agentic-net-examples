using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = "Input";
        string outputDirectory = "Output";
        string thumbnailPath = "thumbnail.jpg";

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Validate thumbnail file
        if (!File.Exists(thumbnailPath))
        {
            Console.Error.WriteLine($"File not found: {thumbnailPath}");
            return;
        }

        // Load thumbnail as RasterImage
        using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
        {
            // Process each JPEG file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.jpg"))
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG image
                using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                {
                    // Ensure ExifData container exists
                    if (jpeg.ExifData == null)
                    {
                        jpeg.ExifData = new Aspose.Imaging.Exif.JpegExifData();
                    }

                    // Assign custom thumbnail
                    jpeg.ExifData.Thumbnail = thumbnail;

                    // Save modified JPEG
                    jpeg.Save(outputPath);
                }
            }
        }
    }
}