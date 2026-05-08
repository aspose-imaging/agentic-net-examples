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
            string inputFolder = @"C:\InputOdg";
            string outputFolder = @"C:\OutputPng";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all ODG files in the input folder
            string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg");

            foreach (string inputPath in odgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output PNG file path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the ODG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG save options with rasterization settings
                    PngOptions pngOptions = new PngOptions();
                    OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                    {
                        // Preserve original size
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}