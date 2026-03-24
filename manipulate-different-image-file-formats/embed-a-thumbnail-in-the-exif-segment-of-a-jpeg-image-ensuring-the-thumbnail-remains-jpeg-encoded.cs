using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input, thumbnail, and output paths
        string inputPath = "input.jpg";
        string thumbnailPath = "thumb.jpg";
        string outputPath = "output/output.jpg";

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
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Load the thumbnail image as a raster image
            using (RasterImage thumbRaster = (RasterImage)Image.Load(thumbnailPath))
            {
                // Embed the thumbnail into the EXIF segment
                jpegImage.ExifData.Thumbnail = thumbRaster;

                // Configure JPEG save options (optional settings)
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 90 // Example quality setting
                };

                // Save the JPEG with the embedded thumbnail
                jpegImage.Save(outputPath, saveOptions);
            }
        }
    }
}