using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class TiffFrameExtractor
{
    static void Main()
    {
        // Path to the multi‑page TIFF file
        string sourcePath = @"C:\Images\multipage.tif";

        // Directory where individual frames will be saved
        string outputDir = @"C:\Images\Frames";
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page TIFF using Aspose.Imaging's load rule
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the loaded image to TiffImage to access frames
            TiffImage tiffImage = (TiffImage)image;

            // Retrieve all frames from the TIFF
            TiffFrame[] frames = tiffImage.Frames;

            // Iterate through each frame and save it as a separate TIFF file
            for (int i = 0; i < frames.Length; i++)
            {
                // Create a new TiffImage that contains only the current frame
                using (TiffImage singleFrameImage = new TiffImage(frames[i]))
                {
                    // Build the output file name (e.g., frame_1.tif)
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.tif");

                    // Save the single‑frame TIFF using Aspose.Imaging's save rule
                    singleFrameImage.Save(outputPath);
                }
            }
        }
    }
}