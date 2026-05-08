using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\temp\multipage.tif";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage multiPage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame in the source image
                for (int i = 0; i < multiPage.Frames.Length; i++)
                {
                    // Retrieve the current frame
                    TiffFrame frame = multiPage.Frames[i];

                    // Create a new TiffImage that contains only this frame
                    using (TiffImage singlePage = new TiffImage(frame))
                    {
                        // Build the output file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF, preserving its metadata
                        singlePage.Save(outputPath);
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