using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = "input\\input.jpg";
        string thumbnailPath = "input\\thumb.jpg";
        string outputPath = "output\\output.jpg";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }
        if (!File.Exists(thumbnailPath))
        {
            Console.Error.WriteLine($"File not found: {thumbnailPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the main JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Load the thumbnail image
            using (RasterImage thumbImg = (RasterImage)Image.Load(thumbnailPath))
            {
                // Initialise EXIF data if necessary and assign the thumbnail
                jpegImage.ExifData = jpegImage.ExifData ?? new JpegExifData();
                jpegImage.ExifData.Thumbnail = thumbImg;
            }

            // Save the image with the new EXIF thumbnail
            jpegImage.Save(outputPath);
        }

        // Verify that the thumbnail was added
        using (JpegImage resultImage = (JpegImage)Image.Load(outputPath))
        {
            JpegExifData jpegExif = resultImage.ExifData as JpegExifData;
            if (jpegExif != null && jpegExif.Thumbnail != null)
            {
                Console.WriteLine("Thumbnail successfully added.");
                Console.WriteLine($"Thumbnail size: {jpegExif.Thumbnail.Width}x{jpegExif.Thumbnail.Height}");
            }
            else
            {
                Console.WriteLine("Thumbnail not found in EXIF data.");
            }
        }
    }
}