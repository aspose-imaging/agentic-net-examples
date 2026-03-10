using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BMP file
        string inputPath = @"C:\temp\sample.bmp";

        // Desired path for the resulting SVG file
        string outputPath = @"C:\temp\sample.svg";

        // Load the BMP image using Aspose.Imaging's unified loader
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Configure rasterization options – the SVG page size should match the bitmap dimensions
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = bmpImage.Size
            };

            // Set up SVG save options and attach the rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // No compression needed for plain SVG (default is false)
                Compress = false
            };

            // Save the image as SVG using the prepared options
            bmpImage.Save(outputPath, svgOptions);
        }
    }
}