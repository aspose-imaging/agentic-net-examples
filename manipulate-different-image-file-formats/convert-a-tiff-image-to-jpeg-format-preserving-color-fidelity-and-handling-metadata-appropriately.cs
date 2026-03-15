using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToJpegConverter
{
    static void Main()
    {
        // Path to the source TIFF image
        string tiffPath = @"C:\Images\source.tif";

        // Desired output path for the JPEG image
        string jpegPath = @"C:\Images\converted.jpg";

        // Load the TIFF image using Aspose.Imaging's load rule
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Configure JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                // Preserve original metadata (EXIF, XMP, etc.)
                KeepMetadata = true,

                // Set desired quality (0-100). Adjust as needed.
                Quality = 90
            };

            // Save the image as JPEG using the save rule
            tiffImage.Save(jpegPath, jpegOptions);
        }
    }
}