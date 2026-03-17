using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Path to the source JPEG file
        string jpegPath = "source.jpg";

        // Desired path for the resulting TGA file
        string tgaPath = "result.tga";

        // Load the JPEG image using Aspose.Imaging's Image.Load method
        // The cast to JpegImage ensures we work with the correct raster type
        using (RasterImage image = (JpegImage)Image.Load(jpegPath))
        {
            // Save the loaded image as TGA using TgaOptions
            image.Save(tgaPath, new TgaOptions());
        }
    }
}