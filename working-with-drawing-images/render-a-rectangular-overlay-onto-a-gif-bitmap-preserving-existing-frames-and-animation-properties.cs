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
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing GIF
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Preserve original loop count
            int originalLoops = gif.LoopsCount;

            // Define overlay rectangle parameters
            int rectX = 10;
            int rectY = 10;
            int rectWidth = 50;
            int rectHeight = 30;
            // Semi‑transparent red color
            Color overlayColor = Color.FromArgb(128, Color.Red);

            // Apply overlay to each frame
            for (int i = 0; i < gif.PageCount; i++)
            {
                // Activate the current frame
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                // Create graphics for the active frame
                Graphics graphics = new Graphics(gif.ActiveFrame);

                // Draw the rectangle overlay
                using (SolidBrush brush = new SolidBrush(overlayColor))
                {
                    graphics.FillRectangle(brush, new Rectangle(rectX, rectY, rectWidth, rectHeight));
                }
            }

            // Restore loop count (if it was modified)
            gif.LoopsCount = originalLoops;

            // Save the modified GIF preserving animation properties
            GifOptions options = new GifOptions
            {
                LoopsCount = originalLoops,
                FullFrame = true
            };
            gif.Save(outputPath, options);
        }
    }
}