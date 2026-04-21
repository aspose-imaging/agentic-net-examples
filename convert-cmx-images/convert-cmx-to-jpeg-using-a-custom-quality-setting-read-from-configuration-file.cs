using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded paths – no argument validation
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.jpg";
        string configPath = @"C:\Images\config.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Read JPEG quality from configuration (default to 90 if missing or invalid)
        int quality = 90;
        if (File.Exists(configPath))
        {
            string text = File.ReadAllText(configPath).Trim();
            if (int.TryParse(text, out int parsed))
            {
                // Clamp to valid JPEG quality range (1‑100)
                quality = Math.Max(1, Math.Min(100, parsed));
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image using CMX load options
        var loadOptions = new CmxLoadOptions();
        using (Image cmxImage = Image.Load(inputPath, loadOptions))
        {
            // Prepare JPEG save options with the custom quality
            var jpegOptions = new JpegOptions
            {
                Quality = quality
            };

            // Save the image as JPEG
            cmxImage.Save(outputPath, jpegOptions);
        }
    }
}