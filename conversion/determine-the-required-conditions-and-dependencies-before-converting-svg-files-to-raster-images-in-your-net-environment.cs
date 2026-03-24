using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.svg";
        string outputPath = @"c:\temp\test.output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image from file stream
        using (Stream stream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(stream))
        {
            // Set rasterization options (default values can be used)
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Configure PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save rasterized image to PNG file
            svgImage.Save(outputPath, pngOptions);
        }
    }
}