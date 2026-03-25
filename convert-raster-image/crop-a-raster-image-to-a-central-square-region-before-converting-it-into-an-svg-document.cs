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

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access cropping functionality
            RasterImage rasterImage = (RasterImage)image;

            // Determine the size of the central square region
            int side = Math.Min(rasterImage.Width, rasterImage.Height);
            int left = (rasterImage.Width - side) / 2;
            int top = (rasterImage.Height - side) / 2;

            // Define the cropping rectangle
            Rectangle cropArea = new Rectangle(left, top, side, side);

            // Crop the image to the central square
            rasterImage.Crop(cropArea);

            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions();

            // Save the cropped image as an SVG document
            rasterImage.Save(outputPath, svgOptions);
        }
    }
}