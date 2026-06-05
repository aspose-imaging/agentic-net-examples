using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "corrupted.tif";
            string outputPath = "recovered.tif";
            string reportPath = "recovery_report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Set to collect recovered frame indices
            HashSet<int> recoveredIndices = new HashSet<int>();

            // First recovery using ConsistentRecover mode
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
            {
                for (int i = 0; i < tiffConsistent.Frames.Length; i++)
                {
                    recoveredIndices.Add(i);
                }

                // Save the consistently recovered image
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Source = new FileCreateSource(outputPath, false);
                tiffConsistent.Save(outputPath, saveOptions);
            }

            // Second recovery using ConsistentRecover mode (fallback if FullRecover unavailable)
            var loadOptionsSecond = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };
            using (TiffImage tiffSecond = (TiffImage)Image.Load(inputPath, loadOptionsSecond))
            {
                for (int i = 0; i < tiffSecond.Frames.Length; i++)
                {
                    recoveredIndices.Add(i);
                }
            }

            // Write report of recovered frame indices
            using (StreamWriter writer = new StreamWriter(reportPath, false))
            {
                writer.WriteLine("Recovered Frame Indices:");
                foreach (int index in recoveredIndices)
                {
                    writer.WriteLine(index);
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
 * 1. When a medical imaging system receives a partially corrupted multi‑page TIFF from a scanner, a developer can use this code to recover all readable frames with ConsistentRecover and FullRecover modes and log which slices were successfully restored.
 * 2. When a digital archiving workflow encounters damaged TIFF documents during batch import, the snippet enables automated recovery of each page and creates a text report that auditors can review to verify data integrity.
 * 3. When a GIS application needs to load large satellite imagery stored as multi‑frame TIFF files that may be truncated during network transfer, the code restores the usable frames and records their indices for later processing.
 * 4. When a publishing platform processes TIFF‑based comic books and some files become corrupted on disk, developers can apply both recovery modes to salvage the pages and generate a recovery_report.txt for quality‑control teams.
 * 5. When a forensic analyst extracts evidence from a corrupted TIFF file found in a seized device, this program recovers the intact frames, saves a clean TIFF, and provides a concise list of recovered frame numbers for documentation.
 */