using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputDirectory = @"C:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates parent directories if needed)
        Directory.CreateDirectory(outputDirectory);

        // Load the multi‑frame TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frames
            TiffImage tiffImage = (TiffImage)image;

            // Iterate over each frame
            TiffFrame[] frames = tiffImage.Frames;
            for (int i = 0; i < frames.Length; i++)
            {
                // Create a new frame based on the current frame (copies pixel data)
                TiffFrame singleFrame = new TiffFrame(frames[i]);

                // Create a new TiffImage containing only this frame
                using (TiffImage singleTiff = new TiffImage(singleFrame))
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.tif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the single‑frame TIFF
                    singleTiff.Save(outputPath);
                }
            }
        }
    }
}