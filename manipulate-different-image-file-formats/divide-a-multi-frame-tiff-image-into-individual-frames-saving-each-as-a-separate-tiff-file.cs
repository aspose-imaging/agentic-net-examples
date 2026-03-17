using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Path to the multi‑frame TIFF file
        string sourcePath = "input.tif";

        // Directory where individual frames will be saved
        string outputDir = "output_frames";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load the multi‑frame TIFF image
        using (TiffImage multiPage = (TiffImage)Image.Load(sourcePath))
        {
            // Retrieve all frames from the image
            TiffFrame[] frames = multiPage.Frames;

            // Iterate through each frame and save it as a separate TIFF file
            for (int i = 0; i < frames.Length; i++)
            {
                // Create a new TiffImage that contains only the current frame
                using (TiffImage singleFrameImage = new TiffImage(frames[i]))
                {
                    // Build the output file name (e.g., frame_1.tif, frame_2.tif, ...)
                    string outPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");

                    // Save the single‑frame TIFF image
                    singleFrameImage.Save(outPath);
                }
            }
        }
    }
}