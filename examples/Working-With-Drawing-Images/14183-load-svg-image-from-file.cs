using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class LoadSvgExample
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgPath = @"C:\Images\sample.svg";

        // Load the SVG image using the SvgImage constructor that accepts a file path
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // Example operation: rasterize the SVG to a PNG file
            // Configure rasterization options (default settings)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

            // Set the rasterization options for the PNG save options
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            string pngOutputPath = @"C:\Images\sample_output.png";
            svgImage.Save(pngOutputPath, pngSaveOptions);
        }
    }
}