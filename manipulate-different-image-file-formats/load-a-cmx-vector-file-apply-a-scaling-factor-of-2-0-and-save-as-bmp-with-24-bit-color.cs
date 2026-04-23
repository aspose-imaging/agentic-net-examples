using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Apply scaling factor of 2.0
                int newWidth = (int)(cmxImage.Width * 2.0);
                int newHeight = (int)(cmxImage.Height * 2.0);
                cmxImage.Resize(newWidth, newHeight);

                // Prepare BMP save options for 24‑bit color
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Save as BMP
                cmxImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}