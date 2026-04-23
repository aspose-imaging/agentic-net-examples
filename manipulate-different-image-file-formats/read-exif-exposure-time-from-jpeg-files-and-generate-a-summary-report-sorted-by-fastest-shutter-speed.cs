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
            string inputDirectory = "Input";
            string outputFile = "Output/report.txt";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToList();

            var records = new List<(string FileName, string ExposureStr, double ExposureVal)>();

            foreach (var filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var jpegExif = image.ExifData;
                    if (jpegExif != null)
                    {
                        string exposureStr = jpegExif.ExposureTime?.ToString();
                        double exposureVal = double.MaxValue;

                        if (!string.IsNullOrEmpty(exposureStr))
                        {
                            int idx = exposureStr.IndexOf('(');
                            string numericPart = idx > 0 ? exposureStr.Substring(0, idx).Trim() : exposureStr.Trim();
                            if (double.TryParse(numericPart, out double parsed))
                            {
                                exposureVal = parsed;
                            }
                        }

                        records.Add((Path.GetFileName(filePath), exposureStr ?? "N/A", exposureVal));
                    }
                }
            }

            var sorted = records.OrderBy(r => r.ExposureVal).ThenBy(r => r.FileName).ToList();

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("Exposure Time Report (sorted by fastest shutter speed):");
                foreach (var rec in sorted)
                {
                    writer.WriteLine($"{rec.FileName}: {rec.ExposureStr}");
                }
            }

            Console.WriteLine($"Report generated at: {outputFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}