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
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
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
            // Cast to SvgImage
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options with page size in inches (e.g., 8.5 x 11 inches)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = new SizeF(8.5f, 11f), // Width and height in inches
                BackgroundColor = Color.White
            };

            // Set up PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}