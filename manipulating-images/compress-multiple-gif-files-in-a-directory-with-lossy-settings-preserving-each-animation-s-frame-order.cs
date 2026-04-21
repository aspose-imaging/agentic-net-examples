using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputGifs";
            string outputDirectory = @"C:\OutputGifs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each GIF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output file path (same file name in the output directory)
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image, apply lossy compression, and save
                using (Image image = Image.Load(inputPath))
                {
                    var saveOptions = new GifOptions
                    {
                        // Enable lossy compression with a recommended value
                        MaxDiff = 80
                    };

                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}