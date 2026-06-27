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
            // Hardcoded input and output paths
            string inputDirectory = "Input";
            string outputPath = "Output/report.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect JPEG files (both .jpg and .jpeg)
            var jpegFiles = new List<string>();
            jpegFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpg"));
            jpegFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpeg"));

            var records = new List<(string FileName, double Value, string Text)>();

            foreach (var filePath in jpegFiles)
            {
                // Validate input file existence
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                // Load the JPEG image
                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exifData = image.ExifData;
                    if (exifData != null)
                    {
                        // ExposureTime may be a rational type; attempt to convert to double
                        object exposureObj = exifData.ExposureTime;
                        string exposureText = exposureObj?.ToString() ?? "N/A";
                        double exposureValue = 0.0;

                        try
                        {
                            exposureValue = Convert.ToDouble(exposureObj);
                        }
                        catch
                        {
                            // If conversion fails, keep default value (0) which will sort last
                        }

                        records.Add((Path.GetFileName(filePath), exposureValue, exposureText));
                    }
                    else
                    {
                        Console.Error.WriteLine($"No EXIF data: {filePath}");
                    }
                }
            }

            // Sort by fastest shutter speed (smallest exposure time)
            var sortedRecords = records.OrderBy(r => r.Value).ToList();

            // Prepare report lines
            var reportLines = new List<string>();
            foreach (var rec in sortedRecords)
            {
                reportLines.Add($"{rec.FileName}: {rec.Text}");
            }

            // Write the summary report
            File.WriteAllLines(outputPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer wants to audit a batch of wedding photos to identify which shots were taken with the fastest shutter speed for motion analysis, they can run this C# code using Aspose.Imaging to read EXIF exposure times from JPEG files and produce a sorted report.
 * 2. When a media archive needs to catalog thousands of historic newspaper scans and verify that high‑speed capture settings were used, the code can extract exposure time metadata from each JPEG and generate a summary list ordered by fastest shutter speed.
 * 3. When a wildlife research team collects camera‑trap images and must quickly find the images captured with the shortest exposure to ensure clear motion capture, they can employ this script to read EXIF data from JPEGs and sort the results.
 * 4. When a digital forensics analyst is examining a suspect’s photo collection and wants to pinpoint images taken with rapid shutter speeds that might indicate video‑like bursts, the program reads the exposure time tags and creates a ranked text report.
 * 5. When an e‑commerce platform processes product photos and needs to confirm that all images were shot with a consistent fast shutter to avoid blur, the developer can use this code to extract and compare EXIF exposure times across JPEG files.
 */