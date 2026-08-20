// HOW-TO: Set Text Rendering Hint for Animated GIF Captions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = "animated_caption.gif";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create the first frame (required for GifImage constructor)
            using (GifFrameBlock firstBlock = new GifFrameBlock(200, 200))
            {
                // Fill the first frame with a white background
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    Graphics g = new Graphics(firstBlock);
                    g.FillRectangle(bgBrush, firstBlock.Bounds);
                }

                // Initialize the GIF image with the first frame
                using (GifImage gifImage = new GifImage(firstBlock))
                {
                    // Add additional frames with captions
                    for (int i = 0; i < 5; i++)
                    {
                        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
                        {
                            Graphics g = new Graphics(frame);
                            // Improve text legibility
                            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

                            // Fill frame background
                            using (SolidBrush bg = new SolidBrush(Color.White))
                            {
                                g.FillRectangle(bg, frame.Bounds);
                            }

                            // Draw caption text
                            using (SolidBrush textBrush = new SolidBrush(Color.Black))
                            {
                                Font font = new Font("Arial", 20);
                                string caption = $"Frame {i + 1}";
                                g.DrawString(caption, font, textBrush, new Point(10, 10));
                            }

                            // Append the frame to the GIF
                            gifImage.AddBlock(frame);
                        }
                    }

                    // Save the animated GIF
                    gifImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate an animated GIF with readable text captions for a slideshow or marketing email.
 * 2. When creating a GIF that displays subtitles or labels on each frame and you want the text to stay sharp on low‑resolution screens.
 * 3. When building a C# application that adds dynamic captions to product demo GIFs and must ensure the text remains legible after compression.
 * 4. When automating the production of GIF memes or tutorial animations where caption quality must not degrade due to anti‑aliasing.
 * 5. When integrating Aspose.Imaging into a reporting tool that outputs animated GIF charts with clear axis labels and titles.
 */
