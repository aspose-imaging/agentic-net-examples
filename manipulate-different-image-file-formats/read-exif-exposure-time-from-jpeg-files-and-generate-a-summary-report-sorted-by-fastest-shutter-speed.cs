// HOW-TO: Read JPEG EXIF Exposure Time and Generate Sorted Shutter Speed Report in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputPath = "Output/report.txt";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var records = new List<(string FileName, string ExposureString, double ExposureValue)>();

            foreach (var file in jpegFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    var exif = img.ExifData;
                    string exposureStr = "N/A";
                    double exposureVal = double.MaxValue;

                    if (exif != null && exif.ExposureTime != null)
                    {
                        exposureStr = exif.ExposureTime.ToString();
                        try
                        {
                            if (exposureStr.Contains("/"))
                            {
                                var parts = exposureStr.Split('/');
                                double num = double.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
                                double den = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                                exposureVal = num / den;
                            }
                            else
                            {
                                exposureVal = double.Parse(exposureStr, System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }
                        catch
                        {
                            exposureVal = double.MaxValue;
                        }
                    }

                    records.Add((Path.GetFileName(file), exposureStr, exposureVal));
                }
            }

            var sorted = records.OrderBy(r => r.ExposureValue).ThenBy(r => r.FileName).ToList();

            var lines = new List<string>();
            lines.Add("FileName,ExposureTime (seconds)");
            foreach (var rec in sorted)
            {
                lines.Add($"{rec.FileName},{rec.ExposureString}");
            }

            File.WriteAllLines(outputPath, lines);
            Console.WriteLine($"Report generated at {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer wants to audit a batch of photos to identify the fastest shutter speeds for quality control.
 * 2. When a media archive needs to extract exposure information from thousands of JPEGs to create a searchable metadata catalog.
 * 3. When a web application must display a summary of camera settings for uploaded images to inform users about shooting conditions.
 * 4. When a forensic analyst requires a quick report of exposure times to detect inconsistencies in image provenance.
 * 5. When a developer builds an automated workflow that sorts images by shutter speed before applying further processing or storage rules.
 */
