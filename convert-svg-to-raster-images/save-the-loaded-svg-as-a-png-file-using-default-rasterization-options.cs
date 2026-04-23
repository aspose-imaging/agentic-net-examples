using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG from file stream and rasterize to PNG
        using (Stream stream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(stream))
        {
            // Default rasterization options
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // PNG save options with rasterization settings
            PngOptions saveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, saveOptions);
        }
    }
}