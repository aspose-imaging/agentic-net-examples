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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options: transparent background and original size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.Transparent,
                PageSize = svgImage.Size
            };

            // Configure PNG options with 300 DPI resolution
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Save as lossless PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}