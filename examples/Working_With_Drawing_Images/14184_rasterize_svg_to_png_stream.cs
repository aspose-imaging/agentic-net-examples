using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (replace with actual path)
        string inputSvgPath = "input.svg";

        // Load SVG image from a file stream
        using (FileStream inputStream = File.OpenRead(inputSvgPath))
        using (SvgImage svgImage = new SvgImage(inputStream))
        {
            // Configure rasterization options (use original SVG size)
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Set PNG save options and attach rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Output stream to hold the rasterized PNG data
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Rasterize SVG and save as PNG into the stream
                svgImage.Save(outputStream, pngOptions);

                // Example: write the stream to a file (optional)
                File.WriteAllBytes("output.png", outputStream.ToArray());
            }
        }
    }
}