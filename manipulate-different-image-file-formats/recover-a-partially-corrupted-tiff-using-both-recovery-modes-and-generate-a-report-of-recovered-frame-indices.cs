using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "corrupted.tif";
            string reportPath = "output/recovery_report.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Recover using ConsistentRecover mode
            var consistentOptions = new LoadOptions { DataRecoveryMode = DataRecoveryMode.ConsistentRecover };
            string consistentReport;
            using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, consistentOptions))
            {
                consistentReport = "ConsistentRecover recovered frames: ";
                for (int i = 0; i < tiffConsistent.Frames.Length; i++)
                {
                    consistentReport += i + " ";
                }
            }

            // Recover using default mode (full recovery if supported)
            var fullOptions = new LoadOptions();
            string fullReport;
            using (TiffImage tiffFull = (TiffImage)Image.Load(inputPath, fullOptions))
            {
                fullReport = "FullRecover recovered frames: ";
                for (int i = 0; i < tiffFull.Frames.Length; i++)
                {
                    fullReport += i + " ";
                }
            }

            // Write report to file
            string reportContent = consistentReport + Environment.NewLine + fullReport;
            File.WriteAllText(reportPath, reportContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}