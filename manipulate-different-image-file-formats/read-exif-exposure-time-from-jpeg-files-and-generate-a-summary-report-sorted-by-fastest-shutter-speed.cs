// HOW-TO: Read JPEG EXIF Exposure Time and Create Sorted Shutter Speed Report in C# (Aspose.Imaging for .NET)
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
            string outputFilePath = "Output\\report.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            var records = new List<(string FileName, double Exposure)>();

            // Get JPEG files (both .jpg and .jpeg)
            var jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToList();

            foreach (var filePath in jpegFiles)
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
                        // ExposureTime is typically a double; fallback to MaxValue if unavailable
                        double exposure = double.MaxValue;
                        try
                        {
                            exposure = Convert.ToDouble(exif.ExposureTime);
                        }
                        catch
                        {
                            // Keep MaxValue for sorting; will appear last
                        }

                        records.Add((Path.GetFileName(filePath), exposure));
                    }
                }
            }

            // Sort by fastest shutter speed (smallest exposure time)
            var sorted = records.OrderBy(r => r.Exposure).ToList();

            var lines = new List<string> { "File\tExposureTime" };
            foreach (var rec in sorted)
            {
                string exposureStr = rec.Exposure == double.MaxValue ? "N/A" : rec.Exposure.ToString();
                lines.Add($"{rec.FileName}\t{exposureStr}");
            }

            File.WriteAllLines(outputFilePath, lines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit a collection of photos to identify which images were captured with the quickest shutter for quality control.
 * 2. When building a photo‑management tool that lists JPEG files by exposure time so photographers can quickly find low‑light shots.
 * 3. When generating a compliance report that documents exposure settings of images stored on a server using Aspose.Imaging in C#.
 * 4. When creating a batch‑processing script that extracts EXIF data from JPEGs and outputs a sortable text summary for archival purposes.
 * 5. When developing a digital asset pipeline that ranks images by fastest shutter speed to prioritize them for further processing or display.
 */
