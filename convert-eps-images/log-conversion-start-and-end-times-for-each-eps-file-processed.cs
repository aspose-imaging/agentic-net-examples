using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
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

            foreach (var file in files)
            {
                // Verify the file exists
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    continue;
                }

                // Log start time
                Console.WriteLine($"Processing started: {file} at {DateTime.Now}");

                // Prepare output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load EPS image and save as PNG
                using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(file))
                {
                    image.Save(outputPath, new PngOptions());
                }

                // Log end time
                Console.WriteLine($"Processing finished: {file} at {DateTime.Now}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}