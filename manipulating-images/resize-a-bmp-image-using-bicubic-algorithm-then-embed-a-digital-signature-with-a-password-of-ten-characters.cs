using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            var raster = (Aspose.Imaging.RasterImage)image;

            // Cache data for performance
            if (!raster.IsCached)
                raster.CacheData();

            // Resize using Bicubic (CubicConvolution) algorithm
            raster.Resize(800, 600, Aspose.Imaging.ResizeType.CubicConvolution);

            // Embed digital signature with a 10-character password
            raster.EmbedDigitalSignature("Passw0rd12");

            // Save the processed image as BMP
            raster.Save(outputPath, new BmpOptions());
        }
    }
}