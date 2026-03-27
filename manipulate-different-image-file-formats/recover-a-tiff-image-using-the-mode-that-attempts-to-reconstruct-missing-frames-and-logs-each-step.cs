using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Log basic information
            Console.WriteLine($"Loaded TIFF image from '{inputPath}'.");
            Console.WriteLine($"Number of frames detected: {tiffImage.Frames.Length}");

            // Attempt to reconstruct missing frames (Aspose.Imaging automatically tries to recover frames on load)
            // Log each frame's dimensions as part of the recovery process
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                var frame = tiffImage.Frames[i];
                Console.WriteLine($"Frame {i + 1}: Width={frame.Width}, Height={frame.Height}");
            }

            // Save the recovered image
            tiffImage.Save(outputPath);
            Console.WriteLine($"Recovered TIFF saved to '{outputPath}'.");
        }
    }
}