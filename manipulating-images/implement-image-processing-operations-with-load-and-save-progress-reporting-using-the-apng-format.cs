using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image with progress reporting
        using (Image image = Image.Load(inputPath, new LoadOptions
        {
            ProgressEventHandler = info =>
            {
                Console.WriteLine($"Loading: {info.EventType}: {info.Value}/{info.MaxValue}");
            }
        }))
        {
            // Prepare APNG save options with progress reporting
            ApngOptions saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ProgressEventHandler = info =>
                {
                    Console.WriteLine($"Saving: {info.EventType}: {info.Value}/{info.MaxValue}");
                },
                // Example: set default frame duration (optional)
                DefaultFrameTime = 500
            };

            // Save the image as APNG using the options
            image.Save(outputPath, saveOptions);
        }
    }
}