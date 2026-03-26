using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Configure rasterization options with a white background
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = svgImage.Size // preserve original size
            };

            // Set up BMP save options and attach the rasterization options
            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the SVG as a BMP file
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}