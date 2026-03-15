using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the source and destination JPEG files
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Retrieve existing EXIF data
            var exif = image.ExifData;
            if (exif != null)
            {
                // Cast to JPEG-specific EXIF container
                var jpegExif = exif as Aspose.Imaging.Exif.JpegExifData;
                if (jpegExif != null)
                {
                    // Modify desired EXIF tags
                    jpegExif.Artist = "John Doe";
                    jpegExif.Copyright = "© 2023 My Company";
                    jpegExif.ImageDescription = "Sample image with modified EXIF";
                    jpegExif.Make = "MyCamera";
                    jpegExif.Model = "ModelX";
                }
            }
            else
            {
                // Create new EXIF data if none exists
                var newExif = new Aspose.Imaging.Exif.JpegExifData
                {
                    Artist = "John Doe",
                    Copyright = "© 2023 My Company",
                    ImageDescription = "Sample image with new EXIF",
                    Make = "MyCamera",
                    Model = "ModelX"
                };
                image.ExifData = newExif;
            }

            // Save the image with the updated EXIF metadata
            image.Save(outputPath);
        }
    }
}