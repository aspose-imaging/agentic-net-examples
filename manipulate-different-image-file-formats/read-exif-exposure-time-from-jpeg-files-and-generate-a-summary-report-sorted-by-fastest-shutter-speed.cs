using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

public class Program
{
    public static void Main()
    {
        // Hardcoded input directory and output report path
        string inputDirectory = @"C:\Images";
        string outputReportPath = @"C:\Images\ExposureReport.txt";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputReportPath));

        // Collect exposure information
        var exposureList = new List<(string FileName, string ExposureString, double ExposureValue)>();

        // Get all JPEG files in the input directory
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

        foreach (string filePath in jpegFiles)
        {
            // Verify the file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(filePath))
            {
                // Retrieve EXIF data as JpegExifData
                var jpegExif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
                if (jpegExif != null)
                {
                    string exposureStr = jpegExif.ExposureTime?.ToString() ?? "N/A";

                    // Attempt to parse a numeric exposure value for sorting
                    double exposureVal = double.MaxValue;
                    if (!string.IsNullOrEmpty(exposureStr))
                    {
                        // Take the part before any '(' character
                        string numericPart = exposureStr.Split('(')[0].Trim();
                        double.TryParse(numericPart, out exposureVal);
                    }

                    exposureList.Add((Path.GetFileName(filePath), exposureStr, exposureVal));
                }
            }
        }

        // Sort by fastest shutter speed (smallest exposure value)
        var sortedList = exposureList.OrderBy(item => item.ExposureValue).ToList();

        // Prepare report lines
        var reportLines = new List<string>();
        reportLines.Add("Exposure Time Report (sorted by fastest shutter speed):");
        reportLines.Add("--------------------------------------------------------");
        foreach (var entry in sortedList)
        {
            reportLines.Add($"{entry.FileName}: Exposure Time = {entry.ExposureString}");
        }

        // Write the report to the output file
        File.WriteAllLines(outputReportPath, reportLines);
    }
}