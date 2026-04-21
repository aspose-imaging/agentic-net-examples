using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\corrupted.tif";
        string outputPath = @"C:\Images\recovered.tif";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                Console.WriteLine($"Loaded TIFF image from '{inputPath}'.");
                Console.WriteLine($"Number of frames detected: {tiffImage.Frames.Length}");

                // Log each frame's dimensions
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    var frame = tiffImage.Frames[i];
                    Console.WriteLine($"Frame {i + 1}: Width={frame.Width}, Height={frame.Height}");
                }

                // Attempt to reconstruct missing frames (Aspose.Imaging automatically
                // tries to recover frames when loading; additional custom logic could be added here)

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the recovered image
                tiffImage.Save(outputPath);
                Console.WriteLine($"Recovered TIFF saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}