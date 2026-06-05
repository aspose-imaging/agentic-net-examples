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
            // Hardcoded input JPEG files
            string[] inputFiles = { "photo1.jpg", "photo2.jpg", "photo3.jpg" };
            // Hardcoded output report path
            string outputPath = "Output/report.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var exposures = new List<(string File, double Value, string Text)>();

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    var exif = image.ExifData;
                    if (exif != null)
                    {
                        var exposureObj = exif.ExposureTime;
                        if (exposureObj != null)
                        {
                            double value = 0;
                            string text = exposureObj.ToString();

                            // Attempt numeric conversion
                            try
                            {
                                value = Convert.ToDouble(exposureObj);
                            }
                            catch
                            {
                                // Fallback parsing from string representation
                                var numericPart = text.Split('(')[0];
                                double.TryParse(numericPart, out value);
                            }

                            exposures.Add((Path.GetFileName(inputPath), value, text));
                        }
                    }
                }
            }

            // Sort by fastest shutter speed (smallest exposure time)
            var sorted = exposures.OrderBy(e => e.Value).ToList();

            var lines = new List<string>
            {
                "Exposure Time Report (sorted by fastest shutter speed):"
            };
            foreach (var item in sorted)
            {
                lines.Add($"{item.File}: {item.Text}");
            }

            File.WriteAllLines(outputPath, lines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer wants to audit a batch of JPEG images to identify which shots were captured with the fastest shutter speed, a developer can use this C# code with Aspose.Imaging to read EXIF exposure times and produce a sorted report.
 * 2. When a media archive needs to catalog image files by their exposure settings for quick retrieval of high‑speed action shots, the code extracts EXIF exposure time from JPEGs and generates a text summary ordered by fastest shutter speed.
 * 3. When a wildlife research project requires analyzing camera trap photos to determine which images were taken with the shortest exposure, developers can employ this snippet to parse JPEG EXIF data and rank the files by shutter speed.
 * 4. When an e‑commerce platform wants to showcase product photos taken with optimal motion blur control, the solution reads JPEG EXIF exposure values and creates a report that highlights the images with the quickest shutter times.
 * 5. When a digital forensics analyst needs to verify the sequence of events by comparing exposure times across multiple JPEG evidence files, the code reads the EXIF exposure time using Aspose.Imaging and outputs a sorted list of the fastest captures.
 */