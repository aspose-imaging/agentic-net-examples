using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"\\RemoteServer\SharedFolder\converted.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF save options (optional settings)
            GifOptions options = new GifOptions
            {
                Interlaced = true,               // Enable interlaced GIF
                DoPaletteCorrection = true       // Apply palette correction
            };

            // Save the image as a GIF to the network share
            image.Save(outputPath, options);
        }
    }
}