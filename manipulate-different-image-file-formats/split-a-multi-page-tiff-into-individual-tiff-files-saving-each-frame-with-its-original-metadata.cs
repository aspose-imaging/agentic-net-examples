using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\temp\multipage.tif";
        string outputDirectory = @"C:\temp\output";

        // Verify the source file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional per requirements)
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑page TIFF
        using (TiffImage multiPage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate through each frame in the source TIFF
            for (int i = 0; i < multiPage.Frames.Length; i++)
            {
                TiffFrame frame = multiPage.Frames[i];

                // Build the output file name (preserving original order)
                string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a new TiffImage containing the current frame
                using (TiffImage singlePage = new TiffImage(frame))
                {
                    // Save the single‑frame TIFF, preserving its metadata
                    singlePage.Save(outputPath);
                }
            }
        }
    }
}