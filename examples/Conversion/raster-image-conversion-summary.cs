using System;
using System.Drawing; // For System.Drawing.Bitmap
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class RasterConversionDemo
{
    static void Main()
    {
        // Path to the source raster image (any supported format, e.g., PNG, JPEG, BMP)
        string sourcePath = @"c:\temp\sample.png";

        // Path where the converted bitmap will be saved
        string bitmapPath = @"c:\temp\sample_converted.bmp";

        // Load the image using Aspose.Imaging. The Image class handles all supported formats.
        using (Image image = Image.Load(sourcePath))
        {
            // Cast to RasterImage to access raster-specific operations.
            // Most raster formats (PNG, JPEG, BMP, etc.) derive from RasterImage.
            RasterImage raster = (RasterImage)image;

            // OPTIONAL: Transform the image to grayscale before conversion.
            // raster.Grayscale();

            // Convert the raster image to a GDI+ Bitmap.
            // The ToBitmap method is defined in the base RasterImage class and overridden in specific formats.
            Bitmap bitmap = raster.ToBitmap();

            // Save the bitmap to disk using the standard .NET Bitmap.Save method.
            // This step demonstrates the seamless transition from Aspose.Imaging to GDI+.
            bitmap.Save(bitmapPath);

            // Dispose the GDI+ bitmap explicitly (optional, as using statement will clean up the Image).
            bitmap.Dispose();
        }

        // At this point, the original Aspose.Imaging image has been disposed,
        // and the converted bitmap is stored at the specified location.
        Console.WriteLine("Raster image successfully converted to bitmap and saved at: " + bitmapPath);
    }
}