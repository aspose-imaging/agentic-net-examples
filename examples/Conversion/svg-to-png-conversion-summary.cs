using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"c:\temp\test.svg";

        // Path where the resulting PNG will be saved
        string outputPngPath = @"c:\temp\test.output.png";

        // Load the SVG image from a file stream
        using (FileStream svgStream = File.OpenRead(inputSvgPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Configure rasterization options – these control how the vector SVG is rasterized
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size as the raster page size (optional but common)
                PageSize = svgImage.Size
            };

            // Create PNG save options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the SVG and save it as a PNG file
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}