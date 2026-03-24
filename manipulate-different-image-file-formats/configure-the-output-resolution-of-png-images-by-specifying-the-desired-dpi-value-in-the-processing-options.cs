using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_resolved.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define the desired DPI values
        double dpiX = 300.0; // horizontal resolution
        double dpiY = 300.0; // vertical resolution

        // Configure PNG save options with the specified resolution
        PngOptions saveOptions = new PngOptions
        {
            ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
        };

        // Load the source image and save it with the new resolution settings
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, saveOptions);
        }
    }
}