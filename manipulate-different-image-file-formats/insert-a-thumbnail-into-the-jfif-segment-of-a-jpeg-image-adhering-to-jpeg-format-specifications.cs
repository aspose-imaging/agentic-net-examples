using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input, thumbnail, and output paths
        string inputPath = "input.jpg";
        string thumbnailPath = "thumb.jpg";
        string outputPath = "output.jpg";

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

        // Load the main JPEG image
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Load the thumbnail image as a raster image
            using (RasterImage thumb = (RasterImage)Image.Load(thumbnailPath))
            {
                // Initialize JFIF segment if necessary and assign the thumbnail
                if (jpegImage.Jfif == null)
                {
                    jpegImage.Jfif = new JFIFData();
                }
                jpegImage.Jfif.Thumbnail = thumb;

                // Save the JPEG with the new JFIF thumbnail
                jpegImage.Save(outputPath);
            }
        }
    }
}