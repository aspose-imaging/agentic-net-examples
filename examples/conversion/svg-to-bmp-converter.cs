using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\sample.svg";

        // Path where the BMP file will be saved
        string outputBmpPath = @"C:\Temp\sample.bmp";

        // Load the SVG image using Aspose.Imaging's unified Load method
        using (Image image = Image.Load(inputSvgPath))
        {
            // Prepare BMP saving options
            BmpOptions bmpOptions = new BmpOptions();

            // For vector images (like SVG) we must provide rasterization options
            // Here we use the default SVG rasterization options and set the page size
            // to match the original image dimensions.
            bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the image as BMP using the configured options
            image.Save(outputBmpPath, bmpOptions);
        }
    }
}