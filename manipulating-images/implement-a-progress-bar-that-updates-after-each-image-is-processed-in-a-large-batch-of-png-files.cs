using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.png");
            int total = inputFiles.Length;
            if (total == 0)
            {
                Console.WriteLine("No PNG files found to process.");
                return;
            }

            for (int i = 0; i < total; i++)
            {
                string inputPath = inputFiles[i];
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_processed.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply progressive PNG option, and save
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions
                    {
                        Progressive = true
                    };
                    image.Save(outputPath, pngOptions);
                }

                // Update simple progress bar
                int progressBarWidth = 30;
                double progressFraction = (i + 1) / (double)total;
                int filledBars = (int)(progressFraction * progressBarWidth);
                string bar = new string('#', filledBars).PadRight(progressBarWidth, '-');
                Console.Write($"\rProcessing: [{bar}] {i + 1}/{total}");
            }

            Console.WriteLine("\nProcessing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}