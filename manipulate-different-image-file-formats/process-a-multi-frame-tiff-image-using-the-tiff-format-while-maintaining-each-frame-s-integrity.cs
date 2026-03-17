using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class MultiFrameTiffProcessor
{
    static void Main()
    {
        // Paths for the source multi‑frame TIFF and the processed output TIFF
        string sourcePath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.tif";

        // Load the existing TIFF image (multi‑frame)
        using (TiffImage sourceTiff = (TiffImage)Image.Load(sourcePath))
        {
            // Ensure the source TIFF actually contains frames
            if (sourceTiff.Frames == null || sourceTiff.Frames.Length == 0)
                throw new InvalidOperationException("The source TIFF does not contain any frames.");

            // Create a new TIFF image using the first frame of the source.
            // This utilizes the TiffImage(TiffFrame) constructor.
            using (TiffImage processedTiff = new TiffImage(sourceTiff.Frames[0]))
            {
                // Add the remaining frames to the new image.
                // The AddFrames method integrates an array of frames while preserving their data.
                TiffFrame[] remainingFrames = sourceTiff.Frames.Skip(1).ToArray();
                if (remainingFrames.Length > 0)
                {
                    processedTiff.AddFrames(remainingFrames);
                }

                // Save the new multi‑frame TIFF, preserving each frame's integrity.
                processedTiff.Save(outputPath);
            }
        }
    }
}