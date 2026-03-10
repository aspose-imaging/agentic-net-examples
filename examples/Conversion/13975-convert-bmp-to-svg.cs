using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source BMP image
            string inputPath = "input.bmp";
            // Desired path for the output SVG file
            string outputPath = "output.svg";

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure vector rasterization options to match the source image size
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save the image as SVG using the configured options
                image.Save(outputPath, new SvgOptions { VectorRasterizationOptions = vectorOptions });
            }
        }
    }
}