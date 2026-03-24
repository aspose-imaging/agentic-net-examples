using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\multipage.tif";
        string outputDirectory = @"C:\temp\frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the multi‑page TIFF
        using (TiffImage multiPageImage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate through each frame
            for (int i = 0; i < multiPageImage.Frames.Length; i++)
            {
                // Build output file path for the current frame
                string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a new TiffImage containing only the current frame
                using (TiffImage singleFrameImage = new TiffImage(multiPageImage.Frames[i]))
                {
                    // Save the single‑frame TIFF
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}