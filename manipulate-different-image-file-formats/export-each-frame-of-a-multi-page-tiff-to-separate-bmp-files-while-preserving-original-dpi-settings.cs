using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\Temp\multi_page.tif";
        string outputDirectory = @"C:\Temp\TiffFrames";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the multi‑page TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            TiffFrame[] frames = tiffImage.Frames;

            for (int i = 0; i < frames.Length; i++)
            {
                // Build the output BMP file path for the current frame
                string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                // Ensure the output directory exists (unconditional per requirements)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the frame as BMP; DPI information is retained automatically
                BmpOptions bmpOptions = new BmpOptions();
                frames[i].Save(outputPath, bmpOptions);
            }
        }
    }
}