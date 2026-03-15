using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Expect input SVG path and output PNG path as command‑line arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input.svg> <output.png>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the SVG image using the unified Image.Load method.
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for the vector image.
            var rasterOptions = new SvgRasterizationOptions
            {
                // Preserve original dimensions.
                PageSize = image.Size,
                // Optional: improve visual quality.
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set up PNG export options and attach the rasterization options.
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG, preserving transparency.
            image.Save(outputPath, pngOptions);
        }
    }
}