using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.gif";
        string outputPath = "output/brightened.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (prevents DirectoryNotFoundException)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Increase brightness (value range: -255 to 255)
            gif.AdjustBrightness(50);

            // Save the modified GIF
            gif.Save(outputPath);
        }
    }
}