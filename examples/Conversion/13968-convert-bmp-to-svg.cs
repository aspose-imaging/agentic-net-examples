using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToSvgConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string inputBmpPath = @"C:\Images\source.bmp";

        // Desired path for the resulting SVG file
        string outputSvgPath = @"C:\Images\converted.svg";

        // Load the BMP image using the unified Image.Load method
        using (Image bmpImage = Image.Load(inputBmpPath))
        {
            // Configure rasterization options – the SVG will have the same page size as the BMP
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = bmpImage.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as SVG using the prepared options
            bmpImage.Save(outputSvgPath, svgSaveOptions);
        }
    }
}