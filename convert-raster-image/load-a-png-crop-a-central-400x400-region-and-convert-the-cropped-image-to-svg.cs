using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
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
                // Determine central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                // Guard against images smaller than the crop size
                if (x < 0 || y < 0)
                {
                    Console.Error.WriteLine("Source image is smaller than the required crop size.");
                    return;
                }

                // Crop the image
                image.Crop(new Rectangle(x, y, cropWidth, cropHeight));

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    // Rasterization options are required even when saving a raster image as SVG
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                // Save the cropped image as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}