using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with 300 DPI
            JpegOptions saveOptions = new JpegOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch
                // Other options (Quality, etc.) can remain default
            };

            // Save the image with the new DPI settings
            image.Save(outputPath, saveOptions);
        }
    }
}