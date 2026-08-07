// HOW-TO: Recover Corrupted TIFF Files Using Consistent and Default Modes in C# (Aspose.Imaging for .NET)
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
            string outputDir = "output";
            string outputPathConsistent = Path.Combine(outputDir, "recovered_consistent.tif");
            string outputPathInconsistent = Path.Combine(outputDir, "recovered_inconsistent.tif");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            int consistentFrames = 0;
            int inconsistentFrames = 0;

            // First recovery: ConsistentRecover mode
            using (var imageConsistent = Image.Load(inputPath, new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            }))
            {
                if (imageConsistent is TiffImage tiffConsistent)
                {
                    consistentFrames = tiffConsistent.Frames?.Length ?? 0;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
                imageConsistent.Save(outputPathConsistent);
                Console.WriteLine($"Consistent recovery frame count: {consistentFrames}");
            }

            // Second recovery: default recovery mode (no explicit DataRecoveryMode)
            using (var imageInconsistent = Image.Load(inputPath, new LoadOptions
            {
                DataBackgroundColor = Color.White
            }))
            {
                if (imageInconsistent is TiffImage tiffInconsistent)
                {
                    inconsistentFrames = tiffInconsistent.Frames?.Length ?? 0;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathInconsistent));
                imageInconsistent.Save(outputPathInconsistent);
                Console.WriteLine($"Inconsistent recovery frame count: {inconsistentFrames}");
            }

            // Compare frame counts
            int difference = Math.Abs(consistentFrames - inconsistentFrames);
            Console.WriteLine($"Difference in frame counts: {difference}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch of scanned documents saved as TIFF becomes partially corrupted, you can use this code to attempt recovery and determine how many pages were successfully restored.
 * 2. When integrating a legacy imaging system that supplies damaged multi‑frame TIFFs, the code helps you recover the images and compare the results of strict versus lenient recovery strategies.
 * 3. When building a diagnostic tool to evaluate the effectiveness of Aspose.Imaging’s DataRecoveryMode settings on real‑world TIFF corruption cases.
 * 4. When you need to automatically process incoming TIFF uploads, recover any usable frames, and log the frame count differences for quality monitoring.
 * 5. When troubleshooting a printing pipeline that fails on corrupted TIFFs, you can recover the file, save both recovery versions, and compare frame counts to decide which mode to use in production.
 */
