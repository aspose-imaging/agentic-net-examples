using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Define the top-left quadrant rectangle
            int cropWidth = image.Width / 2;
            int cropHeight = image.Height / 2;
            var cropRect = new Rectangle(0, 0, cropWidth, cropHeight);

            // Crop the image to the defined rectangle
            image.Crop(cropRect);

            // Save the cropped image as SVG
            var svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}