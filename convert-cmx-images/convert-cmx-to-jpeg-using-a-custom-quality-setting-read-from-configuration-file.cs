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
            string inputPath = @"C:\temp\input.cmx";
            string outputPath = @"C:\temp\output.jpg";
            string configPath = @"C:\temp\config.txt";

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
                JpegOptions jpegOptions = new JpegOptions
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
 * 1. When a print shop needs to batch‑convert legacy CorelDRAW CMX files to web‑ready JPEGs while preserving a client‑specified compression quality stored in a configuration file.
 * 2. When an automated document‑processing pipeline must read CMX artwork from a shared folder, apply a configurable JPEG quality, and save the results to a designated output directory.
 * 3. When a Windows service has to validate the existence of source CMX files, read a numeric quality value from a text configuration, and generate JPEG thumbnails for preview screens.
 * 4. When a migration tool needs to load CMX images using Aspose.Imaging’s CmxLoadOptions, set the JPEG compression level dynamically, and ensure the target folder is created before saving.
 * 5. When troubleshooting image conversion errors, a developer wants a try‑catch block that logs missing files or invalid quality settings while converting CMX to JPEG with a custom quality parameter.
 */