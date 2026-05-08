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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for cropping
                if (image is RasterImage rasterImage)
                {
                    // Determine central square region
                    int side = Math.Min(rasterImage.Width, rasterImage.Height);
                    int left = (rasterImage.Width - side) / 2;
                    int top = (rasterImage.Height - side) / 2;

                    // Crop to the central square
                    var area = new Rectangle(left, top, side, side);
                    rasterImage.Crop(area);
                }

                // Save the (cropped) image as SVG
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}