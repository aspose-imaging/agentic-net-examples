using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
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

                // Access EXIF data and retrieve the thumbnail
                JpegExifData jpegExifData = jpegImage.ExifData as JpegExifData;
                if (jpegExifData == null || jpegExifData.Thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                using (RasterImage thumbnail = jpegExifData.Thumbnail)
                {
                    // Thumbnail dimensions
                    int thumbWidth = thumbnail.Width;
                    int thumbHeight = thumbnail.Height;

                    // Compare sizes and output the result
                    Console.WriteLine($"Original image size:  {originalWidth}x{originalHeight}");
                    Console.WriteLine($"Thumbnail image size: {thumbWidth}x{thumbHeight}");

                    if (thumbWidth < originalWidth && thumbHeight < originalHeight)
                    {
                        Console.WriteLine("Thumbnail is smaller than the original image.");
                    }
                    else if (thumbWidth == originalWidth && thumbHeight == originalHeight)
                    {
                        Console.WriteLine("Thumbnail size matches the original image size.");
                    }
                    else
                    {
                        Console.WriteLine("Thumbnail is larger than the original image (unexpected).");
                    }

                    // Save the thumbnail to a file
                    JpegOptions options = new JpegOptions();
                    thumbnail.Save(thumbnailOutputPath, options);
                    Console.WriteLine($"Thumbnail saved to: {thumbnailOutputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}