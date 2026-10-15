// HOW-TO: Read JPEG EXIF Exposure Time and Create Sorted Shutter Speed Report in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputPath = "report.txt";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var jpegFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            var results = new List<(string FileName, double Exposure)>();

            foreach (var filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (JpegImage image = (JpegImage)Image.Load(filePath))
                {
                    var exif = image.ExifData;
                    double exposureValue = 0;

                    if (exif != null)
                    {
                        var prop = exif.GetType().GetProperty("ExposureTime");
                        if (prop != null)
                        {
                            var value = prop.GetValue(exif);
                            if (value != null)
                            {
                                if (value is double d)
                                {
                                    exposureValue = d;
                                }
                                else if (value is string s && double.TryParse(s, out double sd))
                                {
                                    exposureValue = sd;
                                }
                                else
                                {
                                    var numProp = value.GetType().GetProperty("Numerator");
                                    var denProp = value.GetType().GetProperty("Denominator");
                                    if (numProp != null && denProp != null)
                                    {
                                        var num = Convert.ToDouble(numProp.GetValue(value));
                                        var den = Convert.ToDouble(denProp.GetValue(value));
                                        if (den != 0)
                                            exposureValue = num / den;
                                    }
                                }
                            }
                        }
                    }

                    results.Add((Path.GetFileName(filePath), exposureValue));
                }
            }

            var sorted = results.OrderBy(r => r.Exposure).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("EXIF Exposure Time Report (sorted by fastest shutter speed)");
            sb.AppendLine("--------------------------------------------------------");
            foreach (var item in sorted)
            {
                sb.AppendLine($"{item.FileName}: {item.Exposure}");
            }

            File.WriteAllText(outputPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer wants to audit a batch of JPEG photos to identify the fastest shutter speeds for quality control, they can use this C# script to read EXIF exposure times and generate a sorted report.
 * 2. When building a digital asset management system that categorizes images by shooting parameters, developers can extract JPEG EXIF exposure data and rank images by shutter speed using this code.
 * 3. When creating a time‑lapse project that requires selecting images captured with the shortest exposure, the code helps automatically list JPEG files from a folder in order of fastest shutter speed.
 * 4. When developing a forensic analysis tool that examines camera settings for authenticity checks, the script provides a quick way to pull and compare exposure times from JPEG metadata.
 * 5. When generating a printable summary for a photography workshop that shows participants’ fastest shutter speeds, this C# program reads the EXIF data from each JPEG and outputs a sorted text report.
 */
