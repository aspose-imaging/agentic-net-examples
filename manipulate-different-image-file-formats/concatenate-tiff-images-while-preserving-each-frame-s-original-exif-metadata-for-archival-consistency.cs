using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input TIFF files (replace with actual paths as needed)
            string[] inputPaths = new[]
            {
                @"C:\Images\part1.tif",
                @"C:\Images\part2.tif",
                @"C:\Images\part3.tif"
            };

            // Hard‑coded output TIFF file
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

            // Load the first TIFF – this will become the destination image
            TiffImage combinedTiff = (TiffImage)Image.Load(inputPaths[0]);

            // Append remaining TIFFs frame‑by‑frame
            for (int i = 1; i < inputPaths.Length; i++)
            {
                TiffImage sourceTiff = (TiffImage)Image.Load(inputPaths[i]);
                combinedTiff.Add(sourceTiff);          // Preserve frames and their EXIF data
                sourceTiff.Dispose();                  // Release resources of the source image
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the concatenated multi‑page TIFF
            combinedTiff.Save(outputPath);
            combinedTiff.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}