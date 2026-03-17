using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main(string[] args)
    {
        // Paths for source JPEG, thumbnail image, and output JPEG
        string sourceJpegPath = "source.jpg";
        string thumbnailPath = "thumb.png";
        string outputJpegPath = "output.jpg";

        // Load the thumbnail image as a raster image
        using (RasterImage thumbnail = (RasterImage)Image.Load(thumbnailPath))
        {
            // Load the source JPEG image
            using (JpegImage jpegImage = new JpegImage(sourceJpegPath))
            {
                // Ensure JFIF segment exists and assign the thumbnail
                jpegImage.Jfif = new JFIFData();
                jpegImage.Jfif.Thumbnail = thumbnail;

                // Ensure EXIF data exists and assign the thumbnail
                if (jpegImage.ExifData == null)
                {
                    jpegImage.ExifData = new JpegExifData();
                }
                jpegImage.ExifData.Thumbnail = thumbnail;

                // Save the modified JPEG image
                jpegImage.Save(outputJpegPath);
            }
        }
    }
}