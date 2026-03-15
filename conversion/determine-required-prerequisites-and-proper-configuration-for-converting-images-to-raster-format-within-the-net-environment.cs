using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingRasterConversion
{
    class Program
    {
        static void Main()
        {
            // Prerequisite 1: Add reference to Aspose.Imaging.dll (NuGet package Aspose.Imaging)
            // Prerequisite 2: Ensure the target framework is .NET 6.0 or lower if you need RasterImage.ToBitmap,
            //               because this method is not supported in .NET 7.0+.

            // Input image path (any supported format)
            string inputPath = @"C:\Temp\sample.jpg";

            // Output raster image path (BMP format)
            string outputPath = @"C:\Temp\sample_converted.bmp";

            // Load the source image using the Aspose.Imaging lifecycle Load rule
            using (Image sourceImage = Image.Load(inputPath))
            {
                // The loaded image is a RasterImage (or derived) that can be saved as a raster format.
                // Create BMP save options to define raster-specific settings.
                BmpOptions bmpOptions = new BmpOptions
                {
                    // Example configuration: 24 bits per pixel, no compression
                    BitsPerPixel = 24,
                    Compression = BitmapCompression.Rgb,
                    // Set resolution if required
                    ResolutionSettings = new ResolutionSetting(96, 96)
                };

                // Optional: If you need to work with the image as a System.Drawing.Bitmap,
                // you can use ToBitmap (only on .NET versions < 7.0)
                // System.Drawing.Bitmap gdibitmap = ((RasterImage)sourceImage).ToBitmap();

                // Save the image as a raster BMP using the Aspose.Imaging Save rule
                sourceImage.Save(outputPath, bmpOptions);
            }

            // At this point the image has been converted to a raster BMP file.
            Console.WriteLine("Conversion completed successfully.");
        }
    }
}