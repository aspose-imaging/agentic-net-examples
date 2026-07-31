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
            // Hard‑coded input and output directories
            string inputFolder = @"C:\Input\Svgs";
            string outputFolder = @"C:\Output\Apngs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name, .png extension for APNG)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists (covers cases where outputFolder may be nested)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up APNG options with a default frame delay (e.g., 100 ms)
                    var apngOptions = new ApngOptions
                    {
                        DefaultFrameTime = 100 // milliseconds
                    };

                    // Save as APNG
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate animated PNGs from a library of SVG icons for a web dashboard, they can batch‑convert the SVG files to APNG with a default frame delay using Aspose.Imaging for .NET.
 * 2. When an e‑learning platform wants to turn vector‑based slide illustrations into lightweight animated PNGs for offline mobile consumption, this C# code can process all SVG assets in one folder and output APNG files automatically.
 * 3. When a game UI team requires animated button graphics created from scalable SVG assets, they can run the script to produce APNG animations with consistent timing without manually editing each file.
 * 4. When a marketing automation system needs to embed simple vector animations into email newsletters, the batch conversion from SVG to APNG ensures the images are compatible with most email clients while preserving animation timing.
 * 5. When a CI/CD pipeline must validate that newly added SVG assets are also available as animated PNGs for cross‑platform testing, the code can be integrated to convert the entire SVG directory to APNG with a default 100 ms frame delay.
 */