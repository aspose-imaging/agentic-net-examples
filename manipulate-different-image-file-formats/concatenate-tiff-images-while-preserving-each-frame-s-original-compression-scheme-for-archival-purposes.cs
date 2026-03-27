using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.tif",
            @"C:\Images\input2.tif",
            @"C:\Images\input3.tif"
        };
        string outputPath = @"C:\Images\output.tif";

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

        // Load the first TIFF image – this will become the base image
        using (TiffImage baseImage = (TiffImage)Image.Load(inputPaths[0]))
        {
            // Append frames from the remaining TIFF images
            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (TiffImage srcImage = (TiffImage)Image.Load(inputPaths[i]))
                {
                    // Add all frames from srcImage to baseImage, preserving each frame's original compression
                    baseImage.Add(srcImage);
                }
            }

            // Save the concatenated multi‑page TIFF
            baseImage.Save(outputPath);
        }
    }
}