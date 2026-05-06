using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = { @"C:\Images\input1.tif", @"C:\Images\input2.tif" };
        string outputPath = @"C:\Images\output.tif";

        try
        {
            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image – it will serve as the base image
            TiffImage baseTiff = (TiffImage)Image.Load(inputPaths[0]);

            // Append frames from the remaining TIFF images, preserving their original compression
            for (int i = 1; i < inputPaths.Length; i++)
            {
                TiffImage nextTiff = (TiffImage)Image.Load(inputPaths[i]);
                baseTiff.Add(nextTiff);
                // Dispose the temporary image after adding its frames
                nextTiff.Dispose();
            }

            // Save the concatenated multi‑frame TIFF
            baseTiff.Save(outputPath);
            baseTiff.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}