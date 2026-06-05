using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Temp\corrupted.tif";
        string outputConsistentPath = @"C:\Temp\Recovered_Consistent.tif";
        string outputMaximalPath = @"C:\Temp\Recovered_Maximal.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // ---------- Consistent Recovery ----------
            // Load the corrupted TIFF using ConsistentRecover mode
            var loadOptionsConsistent = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            };

            using (TiffImage tiffConsistent = (TiffImage)Image.Load(inputPath, loadOptionsConsistent))
            {
                // Get recovered frame count
                int consistentFrames = tiffConsistent.Frames.Length;

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputConsistentPath));

                // Save the recovered image
                tiffConsistent.Save(outputConsistentPath);

                Console.WriteLine($"Consistent recovery completed. Frames recovered: {consistentFrames}");
            }

            // ---------- Maximal Recovery ----------
            // Load the corrupted TIFF using MaximalRecover mode
            var loadOptionsMaximal = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.MaximalRecover
            };

            using (TiffImage tiffMaximal = (TiffImage)Image.Load(inputPath, loadOptionsMaximal))
            {
                // Get recovered frame count
                int maximalFrames = tiffMaximal.Frames.Length;

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputMaximalPath));

                // Save the recovered image
                tiffMaximal.Save(outputMaximalPath);

                Console.WriteLine($"Maximal recovery completed. Frames recovered: {maximalFrames}");
            }

            // ---------- Comparison ----------
            // Load both recovered images to compare frame counts (optional, can reuse counts above)
            // For demonstration, we just output that the process is finished.
            Console.WriteLine("Recovery comparison finished.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging system receives a corrupted multi‑page TIFF scan, a developer can use this code to recover the image with both ConsistentRecover and MaximalRecover modes and compare the number of frames restored.
 * 2. When a document management workflow encounters damaged TIFF attachments from legacy scanners, the code helps to automatically attempt two recovery strategies and log which approach yields more pages.
 * 3. When a GIS application needs to salvage satellite imagery stored as multi‑frame TIFF files after a storage failure, the developer can run this routine to recover as many image layers as possible and decide which mode provides the most complete dataset.
 * 4. When an archival software solution must validate the integrity of scanned historical documents, the code can load the corrupted TIFF with Aspose.Imaging, apply sequential recovery, and compare frame counts to determine if the file is usable.
 * 5. When a digital publishing pipeline processes batch TIFF files and some become corrupted during transfer, this snippet enables developers to programmatically recover the files, save separate Consistent and Maximal versions, and choose the version with the higher recovered frame count for further processing.
 */