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
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Determine the top‑left quadrant dimensions
            int cropWidth = image.Width / 2;
            int cropHeight = image.Height / 2;

            // Define the cropping rectangle (top‑left corner)
            var cropArea = new Rectangle(0, 0, cropWidth, cropHeight);

            // Perform the crop
            image.Crop(cropArea);

            // Prepare SVG save options with default rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save the cropped image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}