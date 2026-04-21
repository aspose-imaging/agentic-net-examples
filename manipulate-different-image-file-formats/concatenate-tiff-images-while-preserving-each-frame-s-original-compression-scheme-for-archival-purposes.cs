using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string outputPath = "output.tif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Load the first TIFF image
            using (Image img1 = Image.Load(inputPath1))
            using (TiffImage tiff1 = (TiffImage)img1)
            // Load the second TIFF image
            using (Image img2 = Image.Load(inputPath2))
            using (TiffImage tiff2 = (TiffImage)img2)
            {
                // Collect all frames preserving original compression
                List<TiffFrame> allFrames = new List<TiffFrame>();
                allFrames.AddRange(tiff1.Frames);
                allFrames.AddRange(tiff2.Frames);

                // Create a new multi‑frame TIFF image from the collected frames
                using (TiffImage result = new TiffImage(allFrames.ToArray()))
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the concatenated TIFF
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}