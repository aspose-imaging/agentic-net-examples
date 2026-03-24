using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input TIFF file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\page1.tif",
            @"C:\Images\page2.tif",
            @"C:\Images\page3.tif"
        };

        // Hardcoded output multi‑page TIFF path
        string outputPath = @"C:\Images\combined.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each input file as a TiffFrame
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            // TiffFrame(string path) loads the image data into a frame
            TiffFrame frame = new TiffFrame(inputPath);
            frames.Add(frame);
        }

        // Create a new multi‑page TIFF image from the collected frames
        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            // Save the combined image to the specified output path
            tiffImage.Save(outputPath);
        }

        // Dispose of individual frames (optional, as TiffImage disposes them)
        foreach (TiffFrame frame in frames)
        {
            frame.Dispose();
        }

        Console.WriteLine("Multi‑page TIFF created successfully.");
    }
}