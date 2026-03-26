using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set BMP options with 300 DPI resolution
            BmpOptions bmpOptions = new BmpOptions
            {
                ResolutionSettings = new ResolutionSettings(300, 300)
            };

            // Save the image as BMP using the specified options
            svgImage.Save(outputPath, bmpOptions);
        }
    }
}