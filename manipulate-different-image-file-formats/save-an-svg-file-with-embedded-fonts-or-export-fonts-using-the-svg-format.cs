using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.cdr.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Do not convert text to shapes so fonts can be embedded
                TextAsShapes = false,
                // Use the default resource keeper callback to handle fonts and other resources
                Callback = new SvgResourceKeeperCallback()
            };

            // If the source is a vector image, set appropriate rasterization options
            if (image is VectorImage vectorImage)
            {
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size
                };
            }

            // Save the image as SVG with embedded fonts
            image.Save(outputPath, svgOptions);
        }
    }
}