using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (Directory.CreateDirectory handles null safely)
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑frame TIFF image
        using (TiffImage multiFrameImage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate over each frame in the source image
            for (int i = 0; i < multiFrameImage.Frames.Length; i++)
            {
                // Build the output file path for the current frame
                string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.tif");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a new TiffImage containing only the current frame
                // The frame is cast to RasterImage to use the appropriate constructor
                using (TiffImage singleFrameImage = new TiffImage(new TiffFrame((RasterImage)multiFrameImage.Frames[i])))
                {
                    // Save the single‑frame TIFF
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}