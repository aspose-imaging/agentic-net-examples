using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = @"C:\Images\input.tif";
        string outputDirectory = @"C:\Images\Frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access frames
            TiffImage tiffImage = image as TiffImage;
            if (tiffImage == null)
            {
                Console.Error.WriteLine("The loaded file is not a TIFF image.");
                return;
            }

            // Iterate through each frame
            for (int i = 0; i < tiffImage.Frames.Length; i++)
            {
                // Create a new TiffImage that contains only the current frame
                using (TiffImage singleFrame = new TiffImage(tiffImage.Frames[i]))
                {
                    // Build output file path (PNG format)
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the single-frame image using PNG options
                    singleFrame.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}