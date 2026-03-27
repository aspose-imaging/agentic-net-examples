using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Set up input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create it and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all EPS files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string inputPath in files)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output path (PNG format)
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".png");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Log start time
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Processing started: {inputPath} at {startTime}");

            // Load EPS image and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }

            // Log end time
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Processing finished: {inputPath} at {endTime} (Duration: {(endTime - startTime).TotalSeconds} seconds)");
        }
    }
}