using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        // Output JPEG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.jpg";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for vector image
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };

            // Configure JPEG export options and attach rasterization options
            var jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Quality = 90 // optional quality setting
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}