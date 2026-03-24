using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image, clear its blocks, and save the empty canvas
        using (GifImage gifImage = Image.Load(inputPath) as GifImage)
        {
            if (gifImage == null)
            {
                Console.Error.WriteLine("Failed to load GIF image.");
                return;
            }

            // Remove all existing blocks (frames, graphics control, etc.)
            gifImage.ClearBlocks();

            // Save the cleared image to the output path
            gifImage.Save(outputPath);
        }
    }
}