using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Path to the source PNG file
        string pngPath = "source.png";

        // Desired path for the resulting TGA file
        string tgaPath = "result.tga";

        // Load the PNG image as a generic RasterImage
        using (RasterImage raster = (RasterImage)Image.Load(pngPath))
        {
            // Convert the raster image to a TGA image
            using (TgaImage tgaImage = new TgaImage(raster))
            {
                // Save the TGA image to the specified file
                tgaImage.Save(tgaPath);
            }
        }
    }
}