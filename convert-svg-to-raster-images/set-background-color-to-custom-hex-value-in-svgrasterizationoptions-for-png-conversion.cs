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
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options with custom background color
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.BackgroundColor = Color.FromArgb(255, 0x12, 0x34, 0x56); // Hex #123456
            rasterOptions.PageSize = svgImage.Size;

            // Set PNG save options
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rasterized PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}