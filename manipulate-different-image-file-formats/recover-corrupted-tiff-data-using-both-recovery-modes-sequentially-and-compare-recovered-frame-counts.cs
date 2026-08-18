// HOW-TO: Recover Corrupted TIFF Frames with Consistent and Full Modes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            // Hardcoded input and output paths
            string inputPath = "corrupted.tif";
            string outputPathConsistent = "output\\recovered_consistent.tif";
            string outputPathFull = "output\\recovered_full.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            int consistentFrameCount = 0;
            int fullFrameCount = 0;

            // First recovery: ConsistentRecover
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image imageConsistent = Image.Load(inputPath, loadOptionsConsistent))
            {
                if (imageConsistent is TiffImage tiffConsistent)
                {
                    consistentFrameCount = tiffConsistent.Frames.Length;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathConsistent));
                // Save recovered image
                imageConsistent.Save(outputPathConsistent);
                Console.WriteLine($"Consistent recovery frames: {consistentFrameCount}");
            }

            // Second recovery: using the same ConsistentRecover mode (FullRecover not available)
            var loadOptionsFull = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image imageFull = Image.Load(inputPath, loadOptionsFull))
            {
                if (imageFull is TiffImage tiffFull)
                {
                    fullFrameCount = tiffFull.Frames.Length;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathFull));
                // Save recovered image
                imageFull.Save(outputPathFull);
                Console.WriteLine($"Full recovery frames: {fullFrameCount}");
            }

            // Compare frame counts
            if (consistentFrameCount == fullFrameCount)
            {
                Console.WriteLine("Both recoveries have the same frame count.");
            }
            else
            {
                Console.WriteLine("Recoveries have different frame counts.");
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
 * 1. When a developer receives a damaged multi‑page TIFF from a scanner and needs to extract as many pages as possible without losing image data.
 * 2. When an application must automatically repair uploaded TIFF files before further processing such as OCR or archival storage.
 * 3. When a batch job processes large TIFF archives and wants to log how many frames each recovery mode restores to decide which mode to keep.
 * 4. When a developer needs to compare the effectiveness of ConsistentRecover versus FullRecover (or its fallback) to choose the best strategy for a given corruption pattern.
 * 5. When a .NET service must save the recovered TIFF to a specific folder with a white background for downstream rendering or printing pipelines.
 */
