using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hard‑coded output JPG file
        string outputPath = @"C:\Images\merged_output.jpg";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPG files (uses Aspose.Imaging.Image.Create(string[]))
        using (Image multipageImage = Image.Create(inputPaths))
        {
            // Prepare JPEG save options
            var jpegOptions = new JpegOptions
            {
                // You can adjust quality or other settings here if needed
                Quality = 90
            };

            // Save the resulting image as a single JPEG file
            multipageImage.Save(outputPath, jpegOptions);
        }
    }
}