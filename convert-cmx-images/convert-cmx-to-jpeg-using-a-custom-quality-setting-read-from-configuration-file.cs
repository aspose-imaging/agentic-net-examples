using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\temp\sample.cmx";
            string outputPath = @"C:\temp\output.jpg";
            string configPath = @"C:\temp\config.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify configuration file exists
            if (!File.Exists(configPath))
            {
                Console.Error.WriteLine($"File not found: {configPath}");
                return;
            }

            // Read quality setting from configuration file (expects an integer)
            int quality = 75; // default fallback
            try
            {
                string qualityText = File.ReadAllText(configPath).Trim();
                if (!int.TryParse(qualityText, out quality))
                {
                    Console.Error.WriteLine($"Invalid quality value in config: '{qualityText}'. Using default {quality}.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error reading config: {ex.Message}. Using default quality {quality}.");
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with specific load options
            var loadOptions = new CmxLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare JPEG save options with custom quality
                var jpegOptions = new JpegOptions
                {
                    Quality = quality
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
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
 * 1. When a .NET application must convert legacy CorelDRAW CMX files to web‑friendly JPEG images while allowing the JPEG compression quality to be adjusted via a configuration file.
 * 2. When an automated document‑processing pipeline needs to read a user‑defined quality value from a text config and apply it while saving CMX artwork as JPEG for email attachments.
 * 3. When a Windows service processes incoming CMX graphics and stores them as JPEG thumbnails, using Aspose.Imaging in C# and reading the desired quality from a settings file.
 * 4. When a desktop utility offers end‑users the ability to batch‑convert CMX drawings to JPEG with a configurable compression level stored in a simple config.txt.
 * 5. When a server‑side API receives CMX uploads and must return JPEG previews, using Aspose.Imaging’s CmxLoadOptions and JpegOptions with a quality parameter read from configuration.
 */