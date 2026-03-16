using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Bmp;

class RenderRasterRegionToBmp
{
    static void Main()
    {
        // Paths to source images and output file
        string rasterPath = @"C:\Images\raster.jpg";
        string vectorPath = @"C:\Images\vector.wmf";
        string outputBmpPath = @"C:\Images\output.bmp";

        // Load the raster image (as RasterImage)
        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterPath))
        // Load the vector image (as WmfImage) to obtain its bounds
        using (WmfImage vectorImage = (WmfImage)Image.Load(vectorPath))
        {
            // Define the destination rectangle using the vector image's bounds
            Rectangle destBounds = new Rectangle(0, 0, vectorImage.Width, vectorImage.Height);

            // Optionally, define a source rectangle on the raster image.
            // Here we take the central part of the raster image with the same size as destBounds.
            int srcX = Math.Max(0, (rasterImage.Width - destBounds.Width) / 2);
            int srcY = Math.Max(0, (rasterImage.Height - destBounds.Height) / 2);
            Rectangle srcRect = new Rectangle(srcX, srcY, destBounds.Width, destBounds.Height);

            // Create BMP save options (default options are sufficient for this example)
            BmpOptions bmpOptions = new BmpOptions();

            // Save only the defined region of the raster image to a BMP file,
            // using the vector image's bounds as the destination rectangle.
            // The overload with (filePath, options, boundsRectangle) uses the provided rectangle
            // as the destination bounds; the source rectangle is taken from the image itself.
            rasterImage.Save(outputBmpPath, bmpOptions, destBounds);
        }
    }
}