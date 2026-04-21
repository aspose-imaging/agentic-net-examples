using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage multiPageTiff = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame
                for (int i = 0; i < multiPageTiff.Frames.Length; i++)
                {
                    // Get the current frame
                    TiffFrame frame = multiPageTiff.Frames[i];

                    // Create a new TiffImage containing only this frame
                    using (TiffImage singlePageTiff = new TiffImage(frame))
                    {
                        // Build output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑page TIFF (metadata is preserved with the frame)
                        singlePageTiff.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}