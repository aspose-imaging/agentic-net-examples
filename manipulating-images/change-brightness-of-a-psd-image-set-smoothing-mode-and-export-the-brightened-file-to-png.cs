using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.psd";
        string outputPath = "output.png";

        // Validate input file existence
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
            // Cast to RasterImage for pixel manipulation
            RasterImage raster = (RasterImage)image;

            // Adjust brightness (positive value brightens)
            raster.AdjustBrightness(50);

            // Set smoothing mode via Graphics
            Graphics graphics = new Graphics(raster);
            graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

            // Save the result as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}