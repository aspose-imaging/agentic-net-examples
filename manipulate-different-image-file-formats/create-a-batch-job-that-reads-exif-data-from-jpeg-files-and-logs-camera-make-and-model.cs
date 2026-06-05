using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputFolder = @"C:\Images\Input";
        string outputLogPath = @"C:\Images\Output\exif_log.txt";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputLogPath));

        try
        {
            // Open the log file for writing
            using (var logWriter = new StreamWriter(outputLogPath, false))
            {
                // Get all JPEG files in the input folder
                string[] jpegFiles = Directory.GetFiles(inputFolder, "*.jpg");

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
                        // Access JPEG-specific EXIF data
                        JpegExifData jpegExifData = image.ExifData as JpegExifData;

                        if (jpegExifData != null)
                        {
                            string make = jpegExifData.Make ?? "Unknown";
                            string model = jpegExifData.Model ?? "Unknown";

                            // Log to console
                            Console.WriteLine($"File: {Path.GetFileName(inputPath)} | Make: {make} | Model: {model}");

                            // Write to log file
                            logWriter.WriteLine($"File: {inputPath}");
                            logWriter.WriteLine($"  Camera Make : {make}");
                            logWriter.WriteLine($"  Camera Model: {model}");
                            logWriter.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"File: {Path.GetFileName(inputPath)} does not contain JPEG EXIF data.");
                            logWriter.WriteLine($"File: {inputPath} - No JPEG EXIF data.");
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
 * 1. When a photo‑management system needs to generate a catalog of all JPEG images in a folder and record each picture’s camera make and model for searchable metadata, this Aspose.Imaging C# batch job can read the EXIF data and write it to a log file.
 * 2. When a digital forensics tool must audit a collection of evidence photos to verify the originating devices by extracting camera make and model from JPEG EXIF tags, the code provides a quick way to automate the extraction and logging.
 * 3. When a marketing analytics platform wants to analyze the distribution of camera equipment used by user‑submitted images, it can run this batch process to pull EXIF make/model information from thousands of JPEG files and store the results for reporting.
 * 4. When a cloud‑based image‑processing pipeline needs to tag incoming JPEG uploads with their camera metadata before further transformations, the example demonstrates how to read and log the EXIF make and model using Aspose.Imaging in C#.
 * 5. When a desktop application offers photographers a summary of their shooting gear by scanning a local image library, this code can batch‑process the JPEG files, extract the EXIF camera details, and generate a readable log for the user.
 */