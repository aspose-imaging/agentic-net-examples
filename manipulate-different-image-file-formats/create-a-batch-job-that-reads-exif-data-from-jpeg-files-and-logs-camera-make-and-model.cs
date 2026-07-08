using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = @"C:\Images";
        string outputLogPath = @"C:\Logs\exif_log.txt";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputLogPath));

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            foreach (string inputPath in jpegFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    // Access EXIF data
                    JpegExifData jpegExif = image.ExifData as JpegExifData;

                    if (jpegExif != null)
                    {
                        string make = jpegExif.Make ?? "Unknown";
                        string model = jpegExif.Model ?? "Unknown";

                        string logLine = $"File: {Path.GetFileName(inputPath)} | Make: {make} | Model: {model}";
                        Console.WriteLine(logLine);

                        // Append to log file
                        File.AppendAllText(outputLogPath, logLine + Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine($"No EXIF data found for file: {Path.GetFileName(inputPath)}");
                    }
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
 * 1. When a photographer needs to generate an inventory of all JPEG images in a folder, extracting the camera make and model from EXIF data for cataloging purposes.
 * 2. When a digital asset management system must audit incoming image batches to verify that they were captured with approved camera equipment by reading EXIF metadata using Aspose.Imaging in C#.
 * 3. When a compliance officer wants to log the source devices of JPEG files uploaded to a server, creating a text report of camera make and model for each file.
 * 4. When a developer builds a batch processing tool that scans a directory of JPEG photos, extracts EXIF information, and writes the results to a central log for later analytics.
 * 5. When an e‑commerce platform needs to ensure product photos are taken with high‑quality cameras by automatically reading EXIF make/model tags from JPEG images during bulk import.
 */