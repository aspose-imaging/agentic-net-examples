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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Determine crop rectangle (central 400x400)
            int cropWidth = 400;
            int cropHeight = 400;
            int x = (image.Width - cropWidth) / 2;
            int y = (image.Height - cropHeight) / 2;
            var cropRect = new Rectangle(x, y, cropWidth, cropHeight);

            // Crop the image
            image.Crop(cropRect);

            // Prepare SVG save options
            var svgOptions = new SvgOptions
            {
                // Optional: define rasterization options for the SVG output
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(cropWidth, cropHeight)
                }
            };

            // Save the cropped image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}