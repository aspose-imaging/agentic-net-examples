using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output.tif";
        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Change DPI to 300
            image.HorizontalResolution = 300;
            image.VerticalResolution = 300;

            // Prepare TIFF saving options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}