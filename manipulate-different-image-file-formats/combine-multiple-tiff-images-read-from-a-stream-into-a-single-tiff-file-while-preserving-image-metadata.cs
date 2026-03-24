using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input TIFF file paths
        string[] inputPaths = new string[]
        {
            @"C:\Temp\input1.tif",
            @"C:\Temp\input2.tif",
            @"C:\Temp\input3.tif"
        };

        // Hard‑coded output TIFF file path
        string outputPath = @"C:\Temp\combined_output.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load each TIFF as a frame
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            // Open the source file as a stream
            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create a TiffFrame from the stream (preserves metadata)
                TiffFrame frame = new TiffFrame(stream);
                frames.Add(frame);
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Combine frames into a single multi‑page TIFF
        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            // Save the combined image to the output path
            tiffImage.Save(outputPath);
        }
    }
}