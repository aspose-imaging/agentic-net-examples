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
        string avifInputPath = @"C:\Images\source.avif";
        string svgInputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify AVIF source file exists
        if (!File.Exists(avifInputPath))
        {
            Console.Error.WriteLine($"File not found: {avifInputPath}");
            return;
        }

        // Verify SVG source file exists
        if (!File.Exists(svgInputPath))
        {
            Console.Error.WriteLine($"File not found: {svgInputPath}");
            return;
        }

        // Load AVIF image to obtain its dimensions (used for rasterization size)
        int targetWidth;
        int targetHeight;
        using (Image avifImage = Image.Load(avifInputPath))
        {
            targetWidth = avifImage.Width;
            targetHeight = avifImage.Height;
        }

        // Load SVG from file stream
        using (Stream svgStream = File.OpenRead(svgInputPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Set up rasterization options using dimensions from the AVIF image
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = new Size(targetWidth, targetHeight)
            };

            // Configure PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the rasterized SVG as a PNG file
            svgImage.Save(outputPath, pngOptions);
        }
    }
}