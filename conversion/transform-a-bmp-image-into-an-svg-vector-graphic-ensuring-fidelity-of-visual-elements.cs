using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class BmpToSvgConverter
{
    static void Main()
    {
        // Path to the source BMP file
        string inputPath = @"C:\Temp\sample.bmp";

        // Desired path for the resulting SVG file
        string outputPath = @"C:\Temp\sample.svg";

        // Load the BMP image using Aspose.Imaging's unified loader
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Configure rasterization options so the SVG page matches the BMP dimensions
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = bmpImage.Size // Preserve original size for fidelity
            };

            // Set up SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // For a raster source, rendering text as shapes is unnecessary
                TextAsShapes = false
            };

            // Save the image as an SVG file; the BMP will be embedded as a raster element
            bmpImage.Save(outputPath, svgOptions);
        }
    }
}