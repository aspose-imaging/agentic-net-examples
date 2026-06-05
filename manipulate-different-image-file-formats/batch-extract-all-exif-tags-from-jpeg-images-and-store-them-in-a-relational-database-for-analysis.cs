using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputFile = "Output/exif.csv";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile) ?? ".");

            using (var writer = new StreamWriter(outputFile, false))
            {
                // Write CSV header
                writer.WriteLine("FileName,TagName,TagValue");

                foreach (var filePath in Directory.GetFiles(inputDirectory, "*.jpg"))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (var image = (JpegImage)Image.Load(filePath))
                    {
                        var exifData = image.ExifData;
                        if (exifData != null)
                        {
                            var type = exifData.GetType();
                            var props = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                            foreach (var prop in props)
                            {
                                var value = prop.GetValue(exifData);
                                string valStr = value != null ? value.ToString().Replace("\"", "\"\"") : "NULL";
                                string line = $"\"{Path.GetFileName(filePath)}\",\"{prop.Name}\",\"{valStr}\"";
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"EXIF data exported to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer needs to catalog camera settings from thousands of JPEG photos to generate statistical reports on aperture, shutter speed, and ISO using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform wants to verify image provenance by extracting GPS coordinates and timestamps from product photos before importing them into a SQL Server database.
 * 3. When a digital forensics analyst must batch pull EXIF metadata from seized JPEG files to correlate timestamps with system logs in a relational database.
 * 4. When a marketing team wants to analyze the distribution of device models used by customers by extracting the Make and Model EXIF tags from uploaded images via a .NET backend.
 * 5. When a content management system needs to automatically populate image metadata tables for search indexing by reading EXIF fields from JPEG assets with Aspose.Imaging.
 */