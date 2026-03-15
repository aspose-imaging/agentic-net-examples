using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (use defaults if not provided)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        // Load the image with progress reporting
        var loadOptions = new LoadOptions
        {
            ProgressEventHandler = info =>
                Console.WriteLine($"Load {info.EventType}: {info.Value}/{info.MaxValue}")
        };

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Save the image as APNG with progress reporting
            var saveOptions = new ApngOptions
            {
                ProgressEventHandler = info =>
                    Console.WriteLine($"Save {info.EventType}: {info.Value}/{info.MaxValue}"),
                DefaultFrameTime = 200, // frame duration in ms
                NumPlays = 0 // infinite looping
            };

            image.Save(outputPath, saveOptions);
        }
    }
}