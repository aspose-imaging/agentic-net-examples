using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing frame images and output GIF path
            string inputDir = "input_frames";
            string outputPath = "output/animated.gif";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Get image files for frames
            var frameFiles = Directory.GetFiles(inputDir).OrderBy(f => f).ToArray();
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine($"No image files found in: {inputDir}");
                return;
            }

            // Load first frame and create the initial GIF block
            using (RasterImage firstImg = (RasterImage)Image.Load(frameFiles[0]))
            using (GifFrameBlock firstBlock = new GifFrameBlock(firstImg))
            {
                // Set text rendering hint for better caption legibility
                Graphics graphicsFirst = new Graphics(firstBlock);
                graphicsFirst.TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel;

                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    Font font = new Font("Arial", 12);
                    graphicsFirst.DrawString("Frame 1", font, brush, new PointF(10, 10));
                }

                // Create GIF image with the first block
                using (GifImage gif = new GifImage(firstBlock))
                {
                    // Process remaining frames
                    for (int i = 1; i < frameFiles.Length; i++)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(frameFiles[i]))
                        using (GifFrameBlock block = new GifFrameBlock(img))
                        {
                            Graphics graphics = new Graphics(block);
                            graphics.TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel;

                            using (SolidBrush brush = new SolidBrush(Color.Yellow))
                            {
                                Font font = new Font("Arial", 12);
                                graphics.DrawString($"Frame {i + 1}", font, brush, new PointF(10, 10));
                            }

                            gif.AddBlock(block);
                        }
                    }

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save animated GIF with options
                    GifOptions gifOptions = new GifOptions
                    {
                        LoopsCount = 0 // 0 for infinite looping
                    };
                    gif.Save(outputPath, gifOptions);
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
 * 1. When creating an animated GIF for a marketing email campaign and need captions on each frame to remain crisp on low‑resolution displays, you set the TextRenderingHint on each GifFrameBlock.
 * 2. When generating a step‑by‑step tutorial GIF from screenshots and want the overlaid instructions to be readable on both desktop and mobile browsers, you apply a single‑bit‑per‑pixel text rendering hint before drawing the strings.
 * 3. When building a server‑side C# service that converts a series of PNG charts into an animated GIF with labeled axes, you use Aspose.Imaging to set the text rendering hint so the axis labels stay sharp after compression.
 * 4. When producing an animated GIF for a social media story where each frame includes a caption in a custom font, you configure the Graphics.TextRenderingHint to improve legibility after the GIF is saved.
 * 5. When developing a .NET application that assembles user‑uploaded images into an animated GIF with timestamp overlays, you set the text rendering hint on each frame to ensure the timestamps are clear despite the GIF’s limited color palette.
 */