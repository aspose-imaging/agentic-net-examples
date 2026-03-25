using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // List of WebP files to convert
        List<string> inputFiles = new List<string>
        {
            "input1.webp",
            "input2.webp",
            "input3.webp"
        };

        // Output directory
        string outputFolder = "output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Construct output path with .apng.png extension
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".apng.png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image and save as APNG with a uniform frame delay
            using (Image image = Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    DefaultFrameTime = 200 // frame delay in milliseconds
                };
                image.Save(outputPath, options);
            }
        }
    }
}