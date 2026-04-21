using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Logger
{
    // Simple logger that writes messages with timestamps to the console.
    public static void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now:O} - {message}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories.
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all PNG files in the input directory.
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path.
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_processed.png");

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Log start timestamp.
                Logger.Log($"Start processing: {inputPath}");

                // Load the image, perform any processing, and save.
                using (Image image = Image.Load(inputPath))
                {
                    // Example processing could be added here.
                    // For demonstration, we simply save the image with default PNG options.
                    image.Save(outputPath, new PngOptions());
                }

                // Log end timestamp.
                Logger.Log($"Finished processing: {inputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}