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
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options with a white background
            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = image.Size // preserve original size
            };

            // Set up BMP save options and attach the rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}