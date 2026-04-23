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
            // Hardcoded input and output paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.tif",
                @"C:\Images\input2.tif",
                @"C:\Images\input3.tif"
            };
            string outputPath = @"C:\Images\output.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first TIFF image which will become the target image
            using (TiffImage targetImage = (TiffImage)Image.Load(inputPaths[0]))
            {
                // Append remaining TIFF images, preserving each frame's original compression
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (TiffImage sourceImage = (TiffImage)Image.Load(inputPaths[i]))
                    {
                        targetImage.Add(sourceImage);
                    }
                }

                // Save the concatenated multi‑page TIFF
                targetImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}