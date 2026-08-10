// HOW-TO: Read JPEG EXIF Exposure Time and Create Sorted Report in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            var records = new List<(string FileName, string Exposure)>();

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(file))
                {
                    var exif = image.ExifData;
                    string exposureStr = "N/A";
                    if (exif != null)
                    {
                        var exposure = exif.ExposureTime;
                        if (exposure != null)
                        {
                            exposureStr = exposure.ToString();
                        }
                    }
                    records.Add((Path.GetFileName(file), exposureStr));
                }
            }

            records.Sort((a, b) =>
            {
                double valA = 0;
                double valB = 0;

                string partA = a.Exposure?.Split('(')[0].Trim();
                if (!double.TryParse(partA, out valA))
                {
                    if (!string.IsNullOrEmpty(partA) && partA.Contains("/"))
                    {
                        var nums = partA.Split('/');
                        if (nums.Length == 2 && double.TryParse(nums[0], out double num) && double.TryParse(nums[1], out double den) && den != 0)
                            valA = num / den;
                        else
                            valA = double.MaxValue;
                    }
                    else
                    {
                        valA = double.MaxValue;
                    }
                }

                string partB = b.Exposure?.Split('(')[0].Trim();
                if (!double.TryParse(partB, out valB))
                {
                    if (!string.IsNullOrEmpty(partB) && partB.Contains("/"))
                    {
                        var nums = partB.Split('/');
                        if (nums.Length == 2 && double.TryParse(nums[0], out double num) && double.TryParse(nums[1], out double den) && den != 0)
                            valB = num / den;
                        else
                            valB = double.MaxValue;
                    }
                    else
                    {
                        valB = double.MaxValue;
                    }
                }

                return valA.CompareTo(valB);
            });

            using (var writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("Exposure Time Report (sorted by fastest shutter speed)");
                foreach (var rec in records)
                {
                    writer.WriteLine($"{rec.FileName}: {rec.Exposure}");
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
 * 1. When a photographer wants to list all images in a folder by fastest shutter speed for quick review.
 * 2. When a digital asset management system needs to extract exposure information from JPEGs to generate metadata reports.
 * 3. When a web application must display a summary of camera settings for uploaded photos, sorted by shutter speed.
 * 4. When a forensic analyst needs to audit image files and identify those captured with the shortest exposure times.
 * 5. When a batch processing tool has to create a text report of EXIF exposure values for quality control in a photo‑printing workflow.
 */
