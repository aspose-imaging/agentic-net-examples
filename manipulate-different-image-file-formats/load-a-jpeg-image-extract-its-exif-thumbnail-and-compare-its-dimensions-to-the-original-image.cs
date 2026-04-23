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
        string inputPath = "sample.jpg";
        string outputPath = "thumbnail_output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;

                // Access EXIF data and retrieve the thumbnail
                JpegExifData jpegExifData = jpegImage.ExifData as JpegExifData;
                if (jpegExifData == null || jpegExifData.Thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail found in the image.");
                }
                else
                {
                    // The thumbnail is a RasterImage; ensure proper disposal
                    using (RasterImage thumbnail = jpegExifData.Thumbnail)
                    {
                        // Thumbnail dimensions
                        int thumbWidth = thumbnail.Width;
                        int thumbHeight = thumbnail.Height;

                        // Output dimension comparison
                        Console.WriteLine($"Original dimensions: {originalWidth}x{originalHeight}");
                        Console.WriteLine($"Thumbnail dimensions: {thumbWidth}x{thumbHeight}");

                        // Ensure output directory exists before saving
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the thumbnail to the output path
                        thumbnail.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any runtime exceptions and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}