using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

namespace GifManipulationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output GIF files
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Load the animated GIF
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Preserve original loop count
                int originalLoops = gif.LoopsCount;

                // Iterate through each frame and apply transformations
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the active frame to the current page
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    // Rotate the active frame 90 degrees clockwise
                    gif.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

                // Resize all frames uniformly (full frame resize)
                // Example new dimensions; adjust as needed
                int newWidth = gif.Width / 2;
                int newHeight = gif.Height / 2;
                gif.ResizeFullFrame(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Restore the original loop count
                gif.LoopsCount = originalLoops;

                // Prepare GIF save options to keep metadata and loops
                GifOptions saveOptions = new GifOptions
                {
                    LoopsCount = gif.LoopsCount,
                    KeepMetadata = true
                };

                // Save the modified GIF
                gif.Save(outputPath, saveOptions);
            }
        }
    }
}