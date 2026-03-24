using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Ensure the GIF has at least one frame
            if (gif.PageCount == 0)
            {
                Console.Error.WriteLine("The GIF image contains no frames.");
                return;
            }

            // Set the active frame to the first frame
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

            // Create a Graphics object for the active frame
            Graphics graphics = new Graphics((GifFrameBlock)gif.ActiveFrame);

            // Draw a filled red rectangle on the frame
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                graphics.FillRectangle(brush, new Rectangle(10, 10, 100, 50));
            }

            // Save the modified GIF with default options
            GifOptions options = new GifOptions();
            gif.Save(outputPath, options);
        }
    }
}