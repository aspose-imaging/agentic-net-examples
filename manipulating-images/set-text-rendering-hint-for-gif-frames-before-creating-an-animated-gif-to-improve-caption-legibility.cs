using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\animated.gif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create the first GIF frame (blank white background)
            using (GifFrameBlock firstBlock = new GifFrameBlock(200, 200))
            {
                // Fill background
                Graphics firstGraphics = new Graphics(firstBlock);
                SolidBrush backgroundBrush = new SolidBrush(Color.White);
                firstGraphics.FillRectangle(backgroundBrush, firstBlock.Bounds);

                // Create the GIF image with the first frame
                using (GifImage gifImage = new GifImage(firstBlock))
                {
                    // Prepare a brush for drawing text (black)
                    SolidBrush textBrush = new SolidBrush(Color.Black);

                    // Add additional frames with captions
                    for (int i = 1; i <= 5; i++)
                    {
                        GifFrameBlock frame = new GifFrameBlock(200, 200);
                        Graphics g = new Graphics(frame);
                        g.FillRectangle(backgroundBrush, frame.Bounds);

                        // Draw simple caption (e.g., "Frame 1")
                        // Note: Aspose.Imaging.Graphics supports DrawString; using default rendering hint
                        g.DrawString($"Frame {i}", new Font("Arial", 20), textBrush, new PointF(10, 80));

                        gifImage.AddBlock(frame);
                    }

                    // Set text rendering hint for better caption legibility
                    GifOptions saveOptions = new GifOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                        }
                    };

                    // Save the animated GIF
                    gifImage.Save(outputPath, saveOptions);
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
 * 1. When a C# developer uses Aspose.Imaging to generate an animated GIF for a product tutorial and needs to set a text rendering hint so each frame’s caption remains clear and readable.
 * 2. When building a marketing email generator that creates a multi‑frame GIF with promotional messages, applying a text rendering hint ensures the overlaid text is sharp on every frame.
 * 3. When creating meme‑style animated GIFs in a .NET application, developers can use the code to draw captions with Aspose.Imaging.Graphics and improve legibility by configuring the text rendering hint.
 * 4. When a reporting tool exports step‑by‑step screenshots as an animated GIF, setting the text rendering hint on each frame makes the descriptive labels easy to read on low‑resolution images.
 * 5. When automating e‑learning content that produces animated GIFs with instructional captions, applying a text rendering hint via Aspose.Imaging guarantees high‑quality text rendering across all frames.
 */