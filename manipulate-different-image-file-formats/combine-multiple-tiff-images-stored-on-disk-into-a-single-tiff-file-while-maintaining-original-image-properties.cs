using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input TIFF file paths
        string[] inputPaths = new string[]
        {
            @"c:\temp\image1.tif",
            @"c:\temp\image2.tif",
            @"c:\temp\image3.tif"
        };

        // Hardcoded output TIFF file path
        string outputPath = @"c:\temp\combined.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Collect frames from all input TIFFs
        List<TiffFrame> allFrames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            // Load each TIFF as a frame preserving its original properties
            TiffFrame frame = new TiffFrame(inputPath);
            allFrames.Add(frame);
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a new multi‑page TIFF from the collected frames and save it
        using (TiffImage combinedTiff = new TiffImage(allFrames.ToArray()))
        {
            combinedTiff.Save(outputPath);
        }
    }
}