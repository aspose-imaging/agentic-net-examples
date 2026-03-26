using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.gif";
        string outputPath = @"C:\Temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the GIF image and automatically dispose it after use
        using (Image image = Image.Load(inputPath))
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the image as PNG (conversion from GIF)
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}