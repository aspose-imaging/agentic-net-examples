using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Logger
{
    // Records a start timestamp for a given step
    public static void LogStart(string step)
    {
        Console.WriteLine($"{DateTime.Now:O} - START: {step}");
    }

    // Records an end timestamp for a given step
    public static void LogEnd(string step)
    {
        Console.WriteLine($"{DateTime.Now:O} - END:   {step}");
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image
        Logger.LogStart("Load Image");
        using (Image image = Image.Load(inputPath))
        {
            Logger.LogEnd("Load Image");

            // Example processing: rotate 90 degrees
            Logger.LogStart("Rotate Image");
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Logger.LogEnd("Rotate Image");

            // Save image
            Logger.LogStart("Save Image");
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
            Logger.LogEnd("Save Image");
        }
    }
}