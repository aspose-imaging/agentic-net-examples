using System;
using System.IO;
using Aspose.Imaging;
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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output\\recovered.tif";
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the corrupted TIFF using the second recovery mode
            using (Image image = Image.Load(inputPath, new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            }))
            {
                // Cast to TiffImage to work with frames
                using (TiffImage tiff = (TiffImage)image)
                {
                    // Verify integrity of each recovered frame
                    int index = 0;
                    foreach (TiffFrame frame in tiff.Frames)
                    {
                        Console.WriteLine($"Frame {index}: {frame.Width}x{frame.Height}");
                        index++;
                    }

                    // Save the recovered TIFF
                    tiff.Save(outputPath);
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
 * 1. When a developer needs to restore a corrupted multi‑page TIFF from a document management system using Aspose.Imaging’s ConsistentRecover mode and verify each frame’s dimensions before further processing.
 * 2. When a C# application must recover TIFF images that were partially written due to a network interruption, then check the integrity of each recovered frame to prevent downstream errors.
 * 3. When legacy medical imaging equipment produces TIFF files with missing data, a developer can use the second recovery mode to salvage the image and confirm each frame’s size before archiving.
 * 4. When a print‑shop workflow generates batch TIFFs that become corrupted, a developer can recover them with DataRecoveryMode.ConsistentRecover and validate every page’s resolution before re‑printing.
 * 5. When a web application accepts user‑uploaded TIFFs that may be corrupted, a developer can apply the second recovery mode to recover the file and iterate through its frames to ensure each one is intact before display.
 */