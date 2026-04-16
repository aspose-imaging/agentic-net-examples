using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_enhanced.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access AdjustContrast
            RasterImage raster = (RasterImage)image;

            // Increase contrast by 15%
            raster.AdjustContrast(15f);

            // Prepare SVG save options
            var svgOptions = new SvgOptions();

            // Save the enhanced image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}