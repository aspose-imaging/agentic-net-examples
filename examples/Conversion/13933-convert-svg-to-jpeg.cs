using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                // Preserve original size
                PageSize = image.Size
            };

            // Set JPEG export options and attach rasterization options
            var jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Optional: set quality (0-100)
                Quality = 90
            };

            // Save the rasterized image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}