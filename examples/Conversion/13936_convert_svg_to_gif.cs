using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class SvgToGifConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\input.svg";

        // Desired path for the output GIF file
        string outputGifPath = @"C:\Temp\output.gif";

        // Load the SVG image using Aspose.Imaging's Image.Load method
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure rasterization options for vector (SVG) rendering
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original SVG dimensions
                PageSize = svgImage.Size
            };

            // Prepare GIF save options and attach the rasterization settings
            var gifSaveOptions = new GifOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as GIF using the configured options
            svgImage.Save(outputGifPath, gifSaveOptions);
        }
    }
}