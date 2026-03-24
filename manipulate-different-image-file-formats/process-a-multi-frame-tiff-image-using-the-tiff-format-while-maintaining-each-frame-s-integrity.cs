using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑frame TIFF image
        using (TiffImage sourceImage = (TiffImage)Image.Load(inputPath))
        {
            // Retrieve all frames from the source image
            TiffFrame[] frames = sourceImage.Frames;

            // Create a new TIFF image using the same frames (preserving integrity)
            using (TiffImage destImage = new TiffImage(frames))
            {
                // Save the new TIFF image to the output path
                destImage.Save(outputPath);
            }
        }
    }
}