using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.cmx";
        string outputPath = @"C:\Temp\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Set background to fully transparent
                cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                cmxImage.HasBackgroundColor = true; // indicate that a background color is defined

                // Prepare PNG save options (default supports alpha channel)
                PngOptions pngOptions = new PngOptions
                {
                    // Ensure truecolor with alpha is used
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                };

                // Save as PNG with transparency
                cmxImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}