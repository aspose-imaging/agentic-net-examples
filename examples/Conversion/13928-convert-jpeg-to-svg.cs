using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the source JPEG file
        string inputPath = @"C:\Images\source.jpg";

        // Desired path for the resulting SVG file
        string outputPath = @"C:\Images\converted.svg";

        // Load the JPEG image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options – the page size should match the source image size
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                // Optional: set to true if you want the SVG compressed (svgz). Keep false for plain SVG.
                Compress = false
            };

            // Save the loaded JPEG image as an SVG file using the configured options
            image.Save(outputPath, svgOptions);
        }
    }
}