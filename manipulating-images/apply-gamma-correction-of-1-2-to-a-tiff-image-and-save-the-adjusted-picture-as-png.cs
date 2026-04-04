using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.tif";
        string outputPath = @"c:\temp\sample.AdjustGamma.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, apply gamma correction, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access AdjustGamma
            TiffImage tiffImage = (TiffImage)image;

            // Apply gamma correction with a coefficient of 1.2
            tiffImage.AdjustGamma(1.2f);

            // Save the adjusted image as PNG
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}