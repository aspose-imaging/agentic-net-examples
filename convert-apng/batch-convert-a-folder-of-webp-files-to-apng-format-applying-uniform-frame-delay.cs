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
            string inputFolder = @"C:\InputWebp";
            string outputFolder = @"C:\OutputApng";

            // Uniform frame delay in milliseconds
            uint frameDelay = 200;

            // Get all WebP files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as APNG with the specified frame delay
                using (Image image = Image.Load(inputPath))
                {
                    var apngOptions = new ApngOptions { DefaultFrameTime = frameDelay };
                    image.Save(outputPath, apngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}