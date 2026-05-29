using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WEBP files in the input folder
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WEBP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as APNG with a uniform frame delay (e.g., 100 ms)
                    image.Save(outputPath, new ApngOptions() { DefaultFrameTime = 100 });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}