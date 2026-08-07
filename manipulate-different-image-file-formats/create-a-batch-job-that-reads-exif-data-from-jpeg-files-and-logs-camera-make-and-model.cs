using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing JPEG files
            string inputDirectory = @"C:\Images\Input";

            // Hardcoded output log file path
            string outputLogPath = @"C:\Images\Output\exif_log.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputLogPath));

            // Prepare the log file (overwrite if it exists)
            using (var logWriter = new StreamWriter(outputLogPath, false))
            {
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
                        // Cast the generic ExifData to JpegExifData to access Make and Model
                        JpegExifData jpegExif = image.ExifData as JpegExifData;

                        if (jpegExif != null)
                        {
                            string make = jpegExif.Make ?? "Unknown";
                            string model = jpegExif.Model ?? "Unknown";

                            // Write the information to the console
                            Console.WriteLine($"File: {Path.GetFileName(inputPath)}");
                            Console.WriteLine($"  Camera Make : {make}");
                            Console.WriteLine($"  Camera Model: {model}");

                            // Append the information to the log file
                            logWriter.WriteLine($"File: {Path.GetFileName(inputPath)}");
                            logWriter.WriteLine($"  Camera Make : {make}");
                            logWriter.WriteLine($"  Camera Model: {model}");
                            logWriter.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"File: {Path.GetFileName(inputPath)} - No EXIF data found.");
                            logWriter.WriteLine($"File: {Path.GetFileName(inputPath)} - No EXIF data found.");
                            logWriter.WriteLine();
                        }
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
 * 1. When a photography website needs to generate a catalog of uploaded JPEG images showing each photo’s camera make and model for metadata display, a developer can use this batch job to read EXIF data and log it.
 * 2. When a digital asset management system must audit a large folder of legacy JPEG files to verify that all images were captured with approved camera equipment, this code extracts the camera make and model for reporting.
 * 3. When a forensic analyst wants to quickly identify the source devices of a collection of JPEG evidence files, the batch process reads EXIF tags and writes the camera information to a log for review.
 * 4. When an e‑commerce platform imports product photos and wants to store the originating camera details in a database, the developer can run this C# script to parse EXIF make/model from each JPEG and output them to a text file.
 * 5. When a mobile app development team needs to validate that images captured by users’ phones contain correct EXIF metadata before further processing, they can employ this Aspose.Imaging batch job to read and log the camera make and model of each JPEG file.
 */