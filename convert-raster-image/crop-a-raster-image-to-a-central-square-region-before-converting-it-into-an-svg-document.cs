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
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_cropped.svg";

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
            // Cast to RasterImage to access Width, Height and Crop
            RasterImage raster = (RasterImage)image;

            // Determine the size of the central square
            int side = Math.Min(raster.Width, raster.Height);
            int left = (raster.Width - side) / 2;
            int top = (raster.Height - side) / 2;

            // Define the cropping rectangle
            Rectangle cropArea = new Rectangle(left, top, side, side);

            // Crop to the central square region
            raster.Crop(cropArea);

            // Save the cropped image as SVG
            SvgOptions svgOptions = new SvgOptions();
            raster.Save(outputPath, svgOptions);
        }
    }
}