using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input, thumbnail, and output paths
        string inputPath = @"c:\temp\input.jpg";
        string thumbnailPath = @"c:\temp\thumb.jpg";
        string outputPath = @"c:\temp\output.jpg";

        // Verify input JPEG exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Verify thumbnail image exists
        if (!File.Exists(thumbnailPath))
        {
            Console.Error.WriteLine($"File not found: {thumbnailPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source JPEG image
        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            // Load the thumbnail image as a raster image
            using (RasterImage thumb = (RasterImage)Image.Load(thumbnailPath))
            {
                // Insert thumbnail into EXIF segment
                jpegImage.ExifData.Thumbnail = thumb;

                // Ensure JFIF container is instantiated
                if (jpegImage.Jfif == null)
                {
                    jpegImage.Jfif = new JFIFData();
                }

                // Insert thumbnail into JFIF segment
                jpegImage.Jfif.Thumbnail = thumb;
            }

            // Save the modified JPEG with the thumbnail embedded
            jpegImage.Save(outputPath);
        }
    }
}