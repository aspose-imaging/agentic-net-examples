using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.gif";
        string outputPath = @"\\RemoteServer\SharedFolder\converted.gif";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF save options (optional settings)
            var gifOptions = new GifOptions
            {
                FullFrame = true
            };

            // Save the GIF to the network share
            image.Save(outputPath, gifOptions);
        }

        Console.WriteLine("GIF conversion completed.");
    }
}