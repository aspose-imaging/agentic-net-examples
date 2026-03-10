using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file path
        string inputPath = "input.gif";
        // Output GIF file path after clearing
        string outputPath = "cleared.gif";

        // Load the GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Remove all blocks, effectively clearing the image content
            gif.ClearBlocks();

            // Save the cleared GIF
            gif.Save(outputPath);
        }

        Console.WriteLine("GIF image cleared and saved to: " + outputPath);
    }
}