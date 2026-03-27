using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath1 = @"c:\temp\input1.tif";
        string inputPath2 = @"c:\temp\input2.tif";
        string inputPath3 = @"c:\temp\input3.tif";
        string outputPath = @"c:\temp\merged.tif";

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

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source TIFF images
        using (TiffImage tiff1 = (TiffImage)Image.Load(inputPath1))
        using (TiffImage tiff2 = (TiffImage)Image.Load(inputPath2))
        using (TiffImage tiff3 = (TiffImage)Image.Load(inputPath3))
        {
            // Create a new TIFF image using the first frame of the first source image
            using (TiffImage result = new TiffImage(tiff1.Frames[0]))
            {
                // Add remaining frames from the first image (if any)
                if (tiff1.Frames.Length > 1)
                {
                    result.AddFrames(tiff1.Frames.Skip(1).ToArray());
                }

                // Add all frames from the second and third images
                result.AddFrames(tiff2.Frames);
                result.AddFrames(tiff3.Frames);

                // Save the combined multi‑frame TIFF
                result.Save(outputPath);
            }
        }
    }
}