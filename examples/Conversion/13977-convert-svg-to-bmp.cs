using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\input.svg";

        // Path where the BMP file will be saved
        string outputBmpPath = @"C:\Temp\output.bmp";

        // Load the SVG image using the unified Image.Load method
        using (Image image = Image.Load(inputSvgPath))
        {
            // Prepare BMP export options
            BmpOptions bmpOptions = new BmpOptions();

            // Obtain default rasterization options for the vector image.
            // This ensures the SVG is rasterized correctly before saving as BMP.
            bmpOptions.VectorRasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });

            // Save the rasterized image as BMP using the prepared options
            image.Save(outputBmpPath, bmpOptions);
        }
    }
}