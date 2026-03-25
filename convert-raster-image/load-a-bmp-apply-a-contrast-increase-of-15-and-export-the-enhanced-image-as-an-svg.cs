using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image using the BmpImage constructor
        using (BmpImage bmp = new BmpImage(inputPath))
        {
            // Increase contrast by 15%
            bmp.AdjustContrast(15f);

            // Set up SVG save options
            var svgOptions = new SvgOptions();

            // Save the processed image as SVG
            bmp.Save(outputPath, svgOptions);
        }
    }
}