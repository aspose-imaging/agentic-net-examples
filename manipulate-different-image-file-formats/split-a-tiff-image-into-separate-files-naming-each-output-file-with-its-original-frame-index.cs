using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path using the original frame index
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                    // Ensure the directory for this output file exists (unconditional per rules)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create a new TIFF image containing only the current frame
                    using (TiffImage singleFrameImage = new TiffImage(tiffImage.Frames[i]))
                    {
                        // Save the single‑frame TIFF
                        singleFrameImage.Save(outputPath);
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