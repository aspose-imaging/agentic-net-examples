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
            string inputPath3 = "input3.tif";
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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Load the three source TIFF images
            using (TiffImage tiff1 = (TiffImage)Image.Load(inputPath1))
            using (TiffImage tiff2 = (TiffImage)Image.Load(inputPath2))
            using (TiffImage tiff3 = (TiffImage)Image.Load(inputPath3))
            {
                // Collect all frames from the source images
                var allFrames = new List<TiffFrame>();
                allFrames.AddRange(tiff1.Frames);
                allFrames.AddRange(tiff2.Frames);
                allFrames.AddRange(tiff3.Frames);

                // Create a new multi‑frame TIFF from the collected frames
                using (TiffImage result = new TiffImage(allFrames.ToArray()))
                {
                    // Ensure the output directory exists
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