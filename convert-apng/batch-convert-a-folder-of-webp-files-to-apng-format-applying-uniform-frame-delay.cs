using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputWebp";
        string outputFolder = @"C:\OutputApng";

        // Ensure the output directory exists (will also work if outputFolder is a root path)
        Directory.CreateDirectory(outputFolder);

        // Get all WEBP files in the input folder
        foreach (string inputPath in Directory.GetFiles(inputFolder, "*.webp"))
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output file path (same name with .png extension for APNG)
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WEBP image and save it as APNG with a uniform frame delay (e.g., 100 ms)
            using (Image image = Image.Load(inputPath))
            {
                var apngOptions = new ApngOptions
                {
                    DefaultFrameTime = 100 // frame delay in milliseconds
                };

                image.Save(outputPath, apngOptions);
            }
        }
    }
}