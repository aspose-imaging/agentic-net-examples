using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑frame TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Ensure the output directory exists (creates even if null is returned)
                Directory.CreateDirectory(outputDirectory);

                // Iterate over each frame and save it as an individual TIFF file
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build the output file name using the original frame index
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create a new TiffImage that contains only the current frame
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