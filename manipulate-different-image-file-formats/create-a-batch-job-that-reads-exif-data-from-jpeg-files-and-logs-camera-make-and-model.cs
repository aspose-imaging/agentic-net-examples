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

            // Open the log file for writing
            using (var logWriter = new StreamWriter(outputLogPath, false))
            {
                // Get all JPEG files in the input directory
                string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

                foreach (string filePath in jpegFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Load the JPEG image
                    using (JpegImage image = (JpegImage)Image.Load(filePath))
                    {
                        // Cast EXIF data to JpegExifData to access Make and Model
                        JpegExifData jpegExif = image.ExifData as JpegExifData;

                        if (jpegExif != null)
                        {
                            string make = jpegExif.Make ?? "N/A";
                            string model = jpegExif.Model ?? "N/A";
                            string line = $"{Path.GetFileName(filePath)}: Make = {make}, Model = {model}";
                            Console.WriteLine(line);
                            logWriter.WriteLine(line);
                        }
                        else
                        {
                            string line = $"{Path.GetFileName(filePath)}: No EXIF data.";
                            Console.WriteLine(line);
                            logWriter.WriteLine(line);
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