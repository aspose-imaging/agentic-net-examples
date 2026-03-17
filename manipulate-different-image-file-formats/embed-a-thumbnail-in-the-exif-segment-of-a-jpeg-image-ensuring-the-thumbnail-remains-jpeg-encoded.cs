using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the source JPEG, thumbnail JPEG, and output JPEG
        string sourcePath = "source.jpg";
        string thumbnailPath = "thumbnail.jpg";
        string outputPath = "output.jpg";

        // Load the source JPEG image
        using (JpegImage jpegImage = new JpegImage(sourcePath))
        {
            // Load the thumbnail image as a RasterImage
            using (RasterImage thumbRaster = (RasterImage)Image.Load(thumbnailPath))
            {
                // Assign the thumbnail to the EXIF data (will be JPEG‑encoded automatically)
                jpegImage.ExifData.Thumbnail = thumbRaster;
            }

            // Prepare JPEG save options (keep existing metadata)
            JpegOptions saveOptions = new JpegOptions
            {
                KeepMetadata = true
            };

            // Save the image with the embedded thumbnail
            jpegImage.Save(outputPath, saveOptions);
        }
    }
}