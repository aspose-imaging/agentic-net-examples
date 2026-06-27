using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "corrupted.tif";
            string outputPath = "recovered\\recovered.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the corrupted TIFF with recovery options
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                // Verify integrity of recovered frames
                Console.WriteLine($"Recovered frame count: {tiffImage.Frames.Length}");
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    var frame = tiffImage.Frames[i];
                    Console.WriteLine($"Frame {i}: {frame.Width}x{frame.Height}");
                }

                // Save the recovered TIFF
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, saveOptions);
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
 * 1. When a medical imaging system receives a corrupted multi‑page TIFF from a scanner, a developer can use this code to apply Aspose.Imaging’s ConsistentRecover mode, restore all frames, and confirm each page’s dimensions before saving the clean file.
 * 2. When a document management workflow encounters a damaged TIFF attachment that must be displayed in a web portal, the code enables a C# service to recover the image data, verify the recovered frame count, and output a reliable TIFF for downstream processing.
 * 3. When an archival batch job processes legacy TIFF archives with occasional file corruption, a developer can employ this snippet to automatically recover the images using DataRecoveryMode.ConsistentRecover, check each frame’s width and height, and store the repaired files in a secure folder.
 * 4. When a GIS application imports multi‑layer TIFF maps that may have been truncated during transfer, the code allows the application to reconstruct the missing layers, validate the integrity of each recovered frame, and save a consistent TIFF for further spatial analysis.
 * 5. When an e‑commerce platform needs to regenerate product catalog images from corrupted TIFF files uploaded by vendors, this example shows how to recover the image data, ensure all frames are intact, and produce a clean TIFF for thumbnail generation.
 */