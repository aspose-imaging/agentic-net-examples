// HOW-TO: Recover Corrupted Multi‑Page TIFF and List Recovered Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.tif";
            string outputPath = "output\\recovered.tif";
            string reportPath = "output\\report.txt";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            var consistentIndices = new List<int>();
            var fullIndices = new List<int>();

            // Consistent recovery mode
            using (Aspose.Imaging.Image imgConsistent = Aspose.Imaging.Image.Load(inputPath, new Aspose.Imaging.LoadOptions
            {
                DataRecoveryMode = Aspose.Imaging.DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Aspose.Imaging.Color.White
            }))
            {
                using (TiffImage tiff = (TiffImage)imgConsistent)
                {
                    for (int i = 0; i < tiff.Frames.Length; i++)
                    {
                        if (tiff.Frames[i] != null)
                            consistentIndices.Add(i);
                    }

                    // Save recovered TIFF
                    tiff.Save(outputPath);
                }
            }

            // Full recovery mode (fallback to ConsistentRecover if FullRecover not available)
            using (Aspose.Imaging.Image imgFull = Aspose.Imaging.Image.Load(inputPath, new Aspose.Imaging.LoadOptions
            {
                DataRecoveryMode = Aspose.Imaging.DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Aspose.Imaging.Color.White
            }))
            {
                using (TiffImage tiff = (TiffImage)imgFull)
                {
                    for (int i = 0; i < tiff.Frames.Length; i++)
                    {
                        if (tiff.Frames[i] != null)
                            fullIndices.Add(i);
                    }
                }
            }

            // Generate report
            var reportLines = new List<string>
            {
                "Recovered frame indices (ConsistentRecover):",
                string.Join(", ", consistentIndices),
                "Recovered frame indices (FullRecover):",
                string.Join(", ", fullIndices)
            };

            File.WriteAllLines(reportPath, reportLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a scanned document saved as a multi‑page TIFF becomes partially corrupted and you need to restore the usable pages programmatically in a .NET application.
 * 2. When you want to automatically recover images from a damaged TIFF archive and save a clean version for further processing or archiving.
 * 3. When you need to generate a text report that lists which frame indices were successfully recovered from a corrupted TIFF file.
 * 4. When integrating Aspose.Imaging into a batch‑processing pipeline that must handle faulty TIFF files without manual intervention.
 * 5. When developing a C# utility to extract and preserve intact frames from a TIFF after a failed transfer or storage error.
 */
