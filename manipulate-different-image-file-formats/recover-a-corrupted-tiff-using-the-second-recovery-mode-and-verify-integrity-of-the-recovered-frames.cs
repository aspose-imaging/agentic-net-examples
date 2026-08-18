// HOW-TO: Recover Corrupted TIFF Using Consistent Recover Mode in C# (Aspose.Imaging for .NET)
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
            string outputPath = "recovered.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Set load options for second recovery mode
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            // Load the corrupted TIFF with recovery options
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Cast to TiffImage to access frames
                using (TiffImage tiff = (TiffImage)image)
                {
                    // Verify integrity by enumerating frames
                    Console.WriteLine($"Recovered frame count: {tiff.Frames.Length}");
                    for (int i = 0; i < tiff.Frames.Length; i++)
                    {
                        var frame = tiff.Frames[i];
                        Console.WriteLine($"Frame {i}: {frame.Width}x{frame.Height}");
                    }

                    // Save the recovered TIFF
                    var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiff.Save(outputPath, saveOptions);
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
 * 1. When a batch process receives damaged multi‑page TIFF files from scanners and needs to restore them before further processing.
 * 2. When an application must verify that every frame of a recovered TIFF is intact after applying a recovery algorithm.
 * 3. When a document management system has to automatically fix corrupted TIFF attachments uploaded by users.
 * 4. When a medical imaging workflow requires rebuilding TIFF images with missing data while preserving page dimensions.
 * 5. When a migration tool needs to convert corrupted TIFF archives to clean files for archival storage.
 */
