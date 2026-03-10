using System;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputSvg = "input.svg";
        // Output BMP file path
        string outputBmp = "output.bmp";

        // Load the SVG image
        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputSvg))
        {
            // BMP save options
            var bmpOptions = new BmpOptions();

            // Vector rasterization options required for converting vector formats (SVG) to raster (BMP)
            var rasterOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size for the rasterized bitmap
                PageSize = svgImage.Size
                // Additional SVG rasterization settings can be configured here if needed
            };

            // Assign rasterization options to BMP options
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as BMP
            svgImage.Save(outputBmp, bmpOptions);
        }
    }
}