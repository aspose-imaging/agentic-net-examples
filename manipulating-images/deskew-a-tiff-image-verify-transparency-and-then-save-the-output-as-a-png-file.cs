using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
        {
            // Deskew the image (do not resize canvas, fill background with white)
            tiff.NormalizeAngle(false, Color.White);

            // Verify if the image has an alpha channel (transparency)
            bool hasAlpha = tiff.HasAlpha;
            Console.WriteLine($"Image has transparency: {hasAlpha}");

            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image as PNG
            tiff.Save(outputPath, pngOptions);
        }
    }
}