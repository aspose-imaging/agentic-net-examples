using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input\\corrupted.tif";
            string outputPath = "output\\recovered.tif";
            string reportPath = "output\\recovery_report.txt";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // HashSet to collect recovered frame indices from both recovery modes
            var recoveredIndices = new HashSet<int>();

            // Load with ConsistentRecover mode
            using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            }))
            {
                for (int i = 0; i < tiffConsistent.Frames.Length; i++)
                {
                    recoveredIndices.Add(i);
                }
            }

            // Load with default recovery (full recover)
            using (TiffImage tiffFull = (TiffImage)Image.Load(inputPath))
            {
                // Save the fully recovered image
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffFull.Save(outputPath, tiffOptions);

                for (int i = 0; i < tiffFull.Frames.Length; i++)
                {
                    recoveredIndices.Add(i);
                }
            }

            // Write recovery report
            using (var writer = new StreamWriter(reportPath, false))
            {
                writer.WriteLine("Recovered frame indices:");
                foreach (var index in recoveredIndices)
                {
                    writer.WriteLine(index);
                }
            }

            Console.WriteLine("Recovery completed. Report written to: " + reportPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}