using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output report file
            string inputDirectory = "InputImages";
            string outputPath = "Report\\ExposureReport.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            var exposureData = new List<(string FileName, double ExposureTime)>();

            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exif = image.ExifData;
                    if (exif != null)
                    {
                        dynamic d = exif;
                        double exposure = (double)d.ExposureTime.ToDouble();
                        exposureData.Add((Path.GetFileName(filePath), exposure));
                    }
                }
            }

            // Sort by fastest shutter speed (smallest exposure time)
            var sorted = exposureData.OrderBy(item => item.ExposureTime).ToList();

            // Prepare report lines
            var reportLines = new List<string>();
            reportLines.Add("Exposure Time Report (sorted by fastest shutter speed):");
            foreach (var item in sorted)
            {
                reportLines.Add($"{item.FileName}: {item.ExposureTime}");
            }

            // Write report to the output file
            File.WriteAllLines(outputPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}