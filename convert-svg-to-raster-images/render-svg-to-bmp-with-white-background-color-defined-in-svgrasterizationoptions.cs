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
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Configure rasterization options with a white background
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = svgImage.Size // preserve original size
            };

            // Set BMP save options and attach rasterization options
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}