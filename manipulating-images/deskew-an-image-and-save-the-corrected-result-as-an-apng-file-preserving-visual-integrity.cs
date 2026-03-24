using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Deskew the image without resizing the canvas; fill empty areas with white
            sourceImage.NormalizeAngle(false, Color.White);

            // Prepare APNG save options
            ApngOptions saveOptions = new ApngOptions
            {
                // Single-frame animation with a 1‑second frame duration
                DefaultFrameTime = 1000,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Save the deskewed image as an APNG file
            sourceImage.Save(outputPath, saveOptions);
        }
    }
}