using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class TiffToJpegConverter
{
    static void Main()
    {
        // Path to the source TIFF image
        string tiffPath = @"C:\Images\source.tif";

        // Desired path for the output JPEG image
        string jpegPath = @"C:\Images\converted.jpg";

        // Load the TIFF image using Aspose.Imaging's built‑in load method
        using (Image tiffImage = Image.Load(tiffPath))
        {
            // Configure JPEG export options
            JpegOptions jpegOptions = new JpegOptions
            {
                // Preserve original metadata (EXIF, XMP, etc.)
                KeepMetadata = true,

                // Set the quality level (0‑100). Adjust as needed.
                Quality = 90
            };

            // Save the image as JPEG using the configured options
            tiffImage.Save(jpegPath, jpegOptions);
        }
    }
}