using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging;

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
            string outputPath = "output\\merged.tif";

            // Verify each input file exists
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

            // Load frames from the input TIFF files
            var frames = new List<TiffFrame>();
            frames.Add(new TiffFrame(inputPath1));
            frames.Add(new TiffFrame(inputPath2));
            frames.Add(new TiffFrame(inputPath3));

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new multi‑frame TIFF image from the loaded frames
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                // Save the combined TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}