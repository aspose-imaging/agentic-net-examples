// HOW-TO: Split Multi‑Page TIFF Into Separate Files By Frame Index In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directory paths
        string inputPath = @"C:\Images\input_multi.tif";
        string outputDir = @"C:\Images\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑frame TIFF image
            using (TiffImage multiPage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate over each frame in the source image
                for (int i = 0; i < multiPage.Frames.Length; i++)
                {
                    // Create a new TiffImage that contains only the current frame
                    TiffFrame frame = multiPage.Frames[i];
                    using (TiffImage singleFrameImage = new TiffImage(frame))
                    {
                        // Build output file path using the original frame index
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.tif");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

/*
 * Real-World Use Cases:
 * 1. When you need to extract every page of a scanned multi‑page TIFF so each frame can be processed or shared as an individual image file.
 * 2. When a legacy system requires single‑frame TIFFs, you can split a multi‑frame TIFF and name the outputs with their original frame index for correct ordering.
 * 3. When archiving documents, saving each TIFF frame as “frame_0.tif”, “frame_1.tif”, etc., preserves the original sequence and simplifies retrieval.
 * 4. When performing batch image analysis, separating a multi‑frame TIFF into individual files lets you apply computer‑vision algorithms to each page independently.
 * 5. When automating email workflows, splitting a multi‑page TIFF allows you to attach each page as a separate TIFF attachment with a clear index‑based filename.
 */
