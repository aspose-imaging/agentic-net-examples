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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "report.txt";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var results = new List<(string FileName, double ExposureValue)>();

        // Load JPEG image and extract EXIF exposure time
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            var exif = image.ExifData;
            if (exif != null)
            {
                // ExposureTime may be null or a non‑numeric type; convert safely
                string exposureStr = exif.ExposureTime?.ToString() ?? string.Empty;
                double exposureVal = double.MaxValue;
                if (double.TryParse(exposureStr, out double parsed))
                {
                    exposureVal = parsed;
                }

                results.Add((Path.GetFileName(inputPath), exposureVal));
            }
        }

        // Sort by fastest shutter speed (smallest exposure time)
        var sorted = results.OrderBy(r => r.ExposureValue).ToList();

        // Prepare report lines
        var lines = new List<string>();
        foreach (var entry in sorted)
        {
            string exposureDisplay = entry.ExposureValue == double.MaxValue ? "N/A" : entry.ExposureValue.ToString();
            lines.Add($"{entry.FileName}: ExposureTime = {exposureDisplay}");
        }

        // Write report to output file
        File.WriteAllLines(outputPath, lines);
    }
}