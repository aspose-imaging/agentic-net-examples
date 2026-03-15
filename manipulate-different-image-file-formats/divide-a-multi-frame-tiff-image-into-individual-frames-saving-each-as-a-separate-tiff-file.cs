using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class SplitMultiFrameTiff
{
    static void Main()
    {
        // Path to the source multi‑frame TIFF file
        string sourcePath = "multi_frame.tif";

        // Load the TIFF image (contains multiple frames)
        using (TiffImage multiFrameImage = (TiffImage)Image.Load(sourcePath))
        {
            // Retrieve all frames from the loaded image
            TiffFrame[] frames = multiFrameImage.Frames;

            // Iterate through each frame and save it as an individual TIFF file
            for (int i = 0; i < frames.Length; i++)
            {
                // Create a new TiffImage that contains only the current frame
                using (TiffImage singleFrameImage = new TiffImage(frames[i]))
                {
                    // Define output file name (e.g., frame_1.tif, frame_2.tif, ...)
                    string outputPath = $"frame_{i + 1}.tif";

                    // Save the single‑frame TIFF image
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}