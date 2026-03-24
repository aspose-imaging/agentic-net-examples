using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hard‑coded output JPG file
        string outputPath = @"C:\Images\output\merged.jpg";

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

        // Create a multipage image from the JPG files
        // Uses the Image.Create(string[]) overload as required by the lifecycle rules
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare JPEG save options (default quality)
            JpegOptions jpegOptions = new JpegOptions();

            // Save the combined image as a single JPEG file
            // The Save(string, ImageOptionsBase) overload follows the prescribed save rule
            multipageImage.Save(outputPath, jpegOptions);
        }
    }
}