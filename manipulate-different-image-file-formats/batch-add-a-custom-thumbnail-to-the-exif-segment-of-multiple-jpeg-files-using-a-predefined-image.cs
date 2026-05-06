using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input, output and thumbnail paths
            string inputDir = "Input";
            string outputDir = "Output";
            string thumbnailPath = "thumbnail.jpg";

            // Validate thumbnail file
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputDir);

            // Load the thumbnail image once
            using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
            {
                // Get all JPEG files in the input directory
                string[] files = Directory.GetFiles(inputDir, "*.jpg");
                foreach (string inputPath in files)
                {
                    // Validate each input file
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Prepare output path and ensure its directory exists
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the JPEG image
                    using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                    {
                        // Ensure EXIF data container exists
                        if (jpeg.ExifData == null)
                        {
                            Console.Error.WriteLine($"No EXIF data in: {inputPath}");
                            continue;
                        }

                        // Assign the custom thumbnail
                        jpeg.ExifData.Thumbnail = thumbnail;

                        // Save the modified image
                        jpeg.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}