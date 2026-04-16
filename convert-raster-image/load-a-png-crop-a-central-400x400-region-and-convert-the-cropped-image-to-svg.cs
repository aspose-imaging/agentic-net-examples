using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional call)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Define a central 400x400 rectangle
            int cropWidth = 400;
            int cropHeight = 400;
            int x = (image.Width - cropWidth) / 2;
            int y = (image.Height - cropHeight) / 2;
            var cropRect = new Rectangle(x, y, cropWidth, cropHeight);

            // Crop the image to the defined rectangle
            image.Crop(cropRect);

            // Prepare SVG save options
            var svgOptions = new SvgOptions();

            // Save the cropped image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}