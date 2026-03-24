using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image with progress feedback
        var loadOptions = new Aspose.Imaging.LoadOptions
        {
            ProgressEventHandler = (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info) =>
            {
                Console.WriteLine($"Load {info.EventType} : {info.Value}/{info.MaxValue}");
            }
        };

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath, loadOptions))
        {
            // Example manipulation: resize to half the original dimensions
            image.Resize(image.Width / 2, image.Height / 2, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Save image with progress feedback
            var saveOptions = new PngOptions
            {
                ProgressEventHandler = (Aspose.Imaging.ProgressManagement.ProgressEventHandlerInfo info) =>
                {
                    Console.WriteLine($"Save {info.EventType} : {info.Value}/{info.MaxValue}");
                }
            };

            image.Save(outputPath, saveOptions);
        }
    }
}