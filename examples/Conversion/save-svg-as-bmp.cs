using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class SvgToBmpConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string svgPath = @"C:\Temp\input.svg";

        // Desired path for the output BMP file
        string bmpPath = @"C:\Temp\output.bmp";

        // Load the SVG image
        using (Image image = Image.Load(svgPath))
        {
            // Prepare BMP save options
            BmpOptions bmpOptions = new BmpOptions();

            // Configure rasterization options so the vector SVG is rendered correctly
            bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions
            {
                // Use the original image size for the rasterized bitmap
                PageSize = image.Size
            };

            // Save the image as BMP using the specified options
            image.Save(bmpPath, bmpOptions);
        }
    }
}