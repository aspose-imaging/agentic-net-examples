using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.Exif;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Access EXIF data
                ExifData exifData = tgaImage.ExifData;

                // Serialize EXIF data to JSON (null-safe)
                string json = exifData != null
                    ? JsonSerializer.Serialize(exifData, new JsonSerializerOptions { WriteIndented = true })
                    : "{}";

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
 * 1. When a game developer needs to catalog camera settings stored in TGA textures for a 3‑D asset pipeline, they can extract the EXIF metadata and save it as JSON for easy indexing.
 * 2. When a digital archivist wants to preserve the original capture information of scanned artwork saved as TGA files, extracting EXIF data to a JSON file enables searchable metadata in a content management system.
 * 3. When a photo‑processing service processes batch TGA images from a drone, extracting EXIF tags to JSON allows automated generation of flight logs and compliance reports.
 * 4. When a forensic analyst examines TGA screenshots for tampering, converting the embedded EXIF metadata to JSON provides a readable audit trail for legal documentation.
 * 5. When a C# application integrates with a cloud‑based image catalog, serializing TGA EXIF information to JSON simplifies transmission via REST APIs and downstream analytics.
 */