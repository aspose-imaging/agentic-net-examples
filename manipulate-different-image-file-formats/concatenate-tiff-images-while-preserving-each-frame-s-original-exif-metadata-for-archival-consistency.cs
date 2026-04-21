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
            // Hard‑coded input TIFF files to be concatenated
            string[] inputPaths = new[]
            {
                @"C:\Images\part1.tif",
                @"C:\Images\part2.tif",
                @"C:\Images\part3.tif"
            };

            // Hard‑coded output file
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

            // Load the first TIFF image – it will become the base of the combined image
            TiffImage combinedImage = (TiffImage)Image.Load(inputPaths[0]);

            // Append the remaining TIFF images frame‑by‑frame
            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (TiffImage src = (TiffImage)Image.Load(inputPaths[i]))
                {
                    // Add all frames from the source image to the combined image.
                    // This also copies each frame's EXIF metadata.
                    combinedImage.Add(src);
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the multi‑page TIFF preserving metadata
            combinedImage.Save(outputPath);

            // Dispose the combined image
            combinedImage.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}