using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.cmx";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Set background to fully transparent
                cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;
                cmxImage.HasBackgroundColor = true; // indicate that a background color is defined (transparent)

                // Prepare PNG save options with alpha channel support
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
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