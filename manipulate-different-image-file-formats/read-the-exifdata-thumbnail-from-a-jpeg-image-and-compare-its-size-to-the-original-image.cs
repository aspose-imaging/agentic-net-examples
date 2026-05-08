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
        string thumbnailOutputPath = "output\\thumbnail.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailOutputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;
                Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");

                // Access EXIF thumbnail
                JpegExifData exifData = jpegImage.ExifData as JpegExifData;
                if (exifData?.Thumbnail != null)
                {
                    using (RasterImage thumbnail = exifData.Thumbnail)
                    {
                        int thumbWidth = thumbnail.Width;
                        int thumbHeight = thumbnail.Height;
                        Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                        // Compare sizes
                        if (thumbWidth < originalWidth && thumbHeight < originalHeight)
                        {
                            Console.WriteLine("Thumbnail is smaller than the original image.");
                        }
                        else
                        {
                            Console.WriteLine("Thumbnail is not smaller than the original image.");
                        }

                        // Save the thumbnail to verify output handling
                        thumbnail.Save(thumbnailOutputPath);
                        Console.WriteLine($"Thumbnail saved to: {thumbnailOutputPath}");
                    }
                }
                else
                {
                    Console.WriteLine("No thumbnail found in EXIF data.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}