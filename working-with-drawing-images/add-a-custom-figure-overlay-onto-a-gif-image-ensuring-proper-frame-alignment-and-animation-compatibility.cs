using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output GIF file paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Load the existing GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Iterate through each frame of the GIF
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the current active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    // Create a Graphics object for drawing on the active frame
                    Graphics graphics = new Graphics(gif.ActiveFrame);

                    // Define a red pen for the overlay figure
                    Pen pen = new Pen(Color.Red, 3);

                    // Draw a rectangle overlay with a 10‑pixel margin inside the frame
                    graphics.DrawRectangle(pen,
                        new Rectangle(10, 10,
                                      gif.ActiveFrame.Width - 20,
                                      gif.ActiveFrame.Height - 20));
                    // Note: Graphics does not need disposal and should not be wrapped in a using block
                }

                // Configure GIF save options (preserve animation loops)
                GifOptions options = new GifOptions
                {
                    LoopsCount = gif.LoopsCount // keep original loop count
                };

                // Save the modified GIF with the overlay applied to all frames
                gif.Save(outputPath, options);
            }
        }
    }
}