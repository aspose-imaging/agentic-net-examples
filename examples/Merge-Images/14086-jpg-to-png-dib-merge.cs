using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class MergeJpgToPng
{
    static void Main()
    {
        // Path to the source JPEG image
        string jpgPath = "input.jpg";

        // Path where the resulting PNG image will be saved
        string pngPath = "output.png";

        // Load the JPEG image into an Aspose.Imaging Image object
        using (Image jpgImage = Image.Load(jpgPath))
        {
            // Cast the loaded image to RasterImage (all raster formats, including JPEG, derive from this)
            RasterImage raster = jpgImage as RasterImage;
            if (raster == null)
                throw new InvalidOperationException("Loaded image is not a raster image.");

            // Create a new PNG image from the raster data.
            // This uses the DIB (Device Independent Bitmap) representation internally.
            using (PngImage pngImage = new PngImage(raster))
            {
                // Save the PNG image to the specified file path.
                pngImage.Save(pngPath);
            }
        }
    }
}