using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.psd";
        string outputPath = "Output/straightened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for deskewing
            RasterImage raster = (RasterImage)image;

            // Deskew without resizing canvas, using light gray background for empty areas
            raster.NormalizeAngle(false, Color.LightGray);

            // Save the straightened image as PNG
            PngOptions pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}