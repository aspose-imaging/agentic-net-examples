using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Paths of the source JPG images
        string[] jpgFiles = new string[]
        {
            "image16x16.jpg",
            "image32x32.jpg",
            "image48x48.jpg",
            "image64x64.jpg",
            "image128x128.jpg",
            "image256x256.jpg"
        };

        // Create ICO options – default is PNG format with 32 bits per pixel (high quality)
        IcoOptions icoOptions = new IcoOptions();

        // Initialize an empty ICO image. Width and height are placeholders; individual pages can have different sizes.
        using (IcoImage ico = new IcoImage(256, 256, icoOptions))
        {
            // Add each JPG as a separate page (frame) in the ICO file
            foreach (string jpgPath in jpgFiles)
            {
                // Load the JPG image as a raster image
                using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
                {
                    // Add the raster image to the ICO container.
                    // The AddPage method converts the image to a 32‑bit PNG internally, preserving quality.
                    ico.AddPage(raster);
                }
            }

            // Save the combined ICO file
            ico.Save("combined.ico");
        }
    }
}