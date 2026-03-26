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
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
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
            // Configure rasterization options with white background
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