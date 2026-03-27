using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX vector image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            // Apply scaling factor of 2.0
            cmx.Resize(cmx.Width * 2, cmx.Height * 2);

            // Configure BMP options for 24‑bit color
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            // Save the scaled image as BMP
            cmx.Save(outputPath, bmpOptions);
        }
    }
}