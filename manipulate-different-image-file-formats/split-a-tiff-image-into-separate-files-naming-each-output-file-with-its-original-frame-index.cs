using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.tif";
        string outputDirectory = @"C:\Temp\OutputFrames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the multi-frame TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Iterate over each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                TiffFrame frame = tiffImage.Frames[i];

                // Create a new TiffImage containing only this frame
                using (TiffImage singleFrameImage = new TiffImage(frame))
                {
                    // Build output file path with original frame index
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the single-frame TIFF
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}