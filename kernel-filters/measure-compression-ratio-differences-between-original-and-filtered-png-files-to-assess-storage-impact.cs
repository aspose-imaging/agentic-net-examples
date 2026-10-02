// HOW-TO: Compare Original and Filtered PNG File Sizes and Compression Ratio in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;

namespace CompressionRatioAnalyzer
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string originalDir = @"C:\Data\OriginalPNGs";
                string filteredDir = @"C:\Data\FilteredPNGs";
                string reportPath = @"C:\Data\CompressionReport.txt";

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

                var reportLines = new List<string>();
                reportLines.Add("File,OriginalSize,FilteredSize,CompressionRatio");

                var originalFiles = Directory.GetFiles(originalDir, "*.png");
                foreach (var originalPath in originalFiles)
                {
                    if (!File.Exists(originalPath))
                    {
                        Console.Error.WriteLine($"File not found: {originalPath}");
                        return;
                    }

                    string fileName = Path.GetFileName(originalPath);
                    string filteredPath = Path.Combine(filteredDir, fileName);

                    if (!File.Exists(filteredPath))
                    {
                        Console.Error.WriteLine($"File not found: {filteredPath}");
                        return;
                    }

                    long originalSize = new FileInfo(originalPath).Length;
                    long filteredSize = new FileInfo(filteredPath).Length;
                    double ratio = filteredSize == 0 ? 0 : (double)originalSize / filteredSize;

                    reportLines.Add($"{fileName},{originalSize},{filteredSize},{ratio:F3}");
                }

                File.WriteAllLines(reportPath, reportLines);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate how much storage space a PNG filtering algorithm saves across a batch of images, you can use this code to calculate original and filtered file sizes and their compression ratios.
 * 2. When generating a quality‑control report for an image‑processing pipeline, the script provides a CSV‑style list of each PNG’s size before and after applying filters.
 * 3. When comparing different image‑optimisation settings to choose the most efficient one, the program quantifies the impact by computing the ratio of original to filtered file sizes.
 * 4. When auditing archival storage to ensure that compressed PNGs meet size‑reduction targets, this utility quickly identifies files that do not achieve the desired compression.
 * 5. When automating a CI/CD build that includes image assets, the code can be integrated to verify that post‑processing steps do not increase PNG file size beyond acceptable limits.
 */
