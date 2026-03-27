using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
        {
            // Ensure EXIF container exists
            if (jpeg.ExifData == null)
                jpeg.ExifData = new Aspose.Imaging.Exif.JpegExifData();

            // Ensure JFIF container exists
            if (jpeg.Jfif == null)
                jpeg.Jfif = new JFIFData();

            // Determine thumbnail size (e.g., 25% of original)
            int thumbWidth = jpeg.Width / 4;
            int thumbHeight = jpeg.Height / 4;

            // Create a thumbnail by loading the image again and resizing
            using (RasterImage thumb = (RasterImage)Image.Load(inputPath))
            {
                thumb.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                // Assign the thumbnail to both EXIF and JFIF segments
                jpeg.ExifData.Thumbnail = thumb;
                jpeg.Jfif.Thumbnail = thumb;

                // Save the modified JPEG with the new thumbnails
                jpeg.Save(outputPath);
            }
        }
    }
}