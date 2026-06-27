using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.json";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image
            using (TgaImage image = (TgaImage)Image.Load(inputPath))
            {
                // Extract EXIF data
                var exifData = image.ExifData;

                // Serialize EXIF data to JSON (null-safe)
                string json = JsonSerializer.Serialize(exifData, new JsonSerializerOptions { WriteIndented = true });

                // Write JSON to the output file
                File.WriteAllText(outputPath, json);
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
 * 1. When a game developer needs to catalog camera settings from TGA textures used in a Unity project, they can extract the EXIF metadata and store it as JSON for easy analysis.
 * 2. When a digital forensics analyst processes TGA screenshots from a security system and wants a searchable JSON report of embedded EXIF timestamps and GPS coordinates, this code provides the extraction.
 * 3. When a batch image conversion pipeline must preserve original EXIF information from TGA files before converting them to PNG, the JSON file can be used to reapply metadata later.
 * 4. When a content management system imports TGA assets and requires a human‑readable metadata file for SEO and asset tracking, developers can generate the JSON using this snippet.
 * 5. When a scientific imaging application records experimental parameters in the EXIF fields of TGA files and needs to export those parameters to a JSON configuration file for downstream data processing, this code fulfills the requirement.
 */