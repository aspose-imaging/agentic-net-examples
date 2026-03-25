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
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (BmpImage bmp = new BmpImage(inputPath))
        {
            // Calculate half dimensions (integer division)
            int newWidth = bmp.Width / 2;
            int newHeight = bmp.Height / 2;

            // Resize the BMP image to the new dimensions
            bmp.Resize(newWidth, newHeight);

            // Prepare SVG save options (default settings)
            SvgOptions svgOptions = new SvgOptions();

            // Save the resized image as SVG
            bmp.Save(outputPath, svgOptions);
        }
    }
}