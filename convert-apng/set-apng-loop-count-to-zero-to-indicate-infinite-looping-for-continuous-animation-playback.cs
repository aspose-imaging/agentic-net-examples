using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (can be any animated format supported by Aspose.Imaging)
        using (Image image = Image.Load(inputPath))
        {
            // Configure APNG options with infinite looping (NumPlays = 0)
            ApngOptions apngOptions = new ApngOptions
            {
                NumPlays = 0 // 0 indicates infinite looping
            };

            // Save the image as APNG with the specified options
            image.Save(outputPath, apngOptions);
        }
    }
}