using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with 150 DPI resolution
            PngOptions saveOptions = new PngOptions
            {
                ResolutionSettings = new ResolutionSetting(150.0, 150.0)
            };

            // Save the image as PNG using the specified options
            image.Save(outputPath, saveOptions);
        }
    }
}