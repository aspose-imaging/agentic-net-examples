using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.cmx";
            string outputPath = "output.jpg";
            string configPath = "config.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify config file exists (optional, default quality will be used if missing)
            int quality = 90; // default quality
            if (File.Exists(configPath))
            {
                string text = File.ReadAllText(configPath).Trim();
                if (int.TryParse(text, out int parsed) && parsed >= 1 && parsed <= 100)
                {
                    quality = parsed;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with specific load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Prepare JPEG save options with custom quality
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = quality
                };

                // Save as JPEG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}