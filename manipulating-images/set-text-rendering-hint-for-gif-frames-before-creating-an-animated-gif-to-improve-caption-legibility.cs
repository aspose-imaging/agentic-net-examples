// HOW-TO: Set Text Rendering Hint for Animated GIF Captions in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string frame1Path = "frame1.png";
            string frame2Path = "frame2.png";
            string outputPath = "output.gif";

            if (!File.Exists(frame1Path))
            {
                Console.Error.WriteLine($"File not found: {frame1Path}");
                return;
            }
            if (!File.Exists(frame2Path))
            {
                Console.Error.WriteLine($"File not found: {frame2Path}");
                return;
            }

            using (Aspose.Imaging.RasterImage frame1 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(frame1Path))
            using (Aspose.Imaging.RasterImage frame2 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(frame2Path))
            {
                int width = frame1.Width;
                int height = frame1.Height;

                using (GifImage gif = (GifImage)Aspose.Imaging.Image.Create(new GifOptions(), width, height))
                {
                    gif.AddPage(frame1);
                    gif.AddPage(frame2);

                    for (int i = 0; i < gif.PageCount; i++)
                    {
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(gif.ActiveFrame);
                        graphics.TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAliasGridFit;

                        using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                        {
                            Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                            graphics.DrawString($"Frame {i + 1}", font, brush, new Aspose.Imaging.PointF(10, 10));
                        }
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    gif.Save(outputPath, new GifOptions());
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
 * 1. When you need to add readable text labels to each frame of an animated GIF generated from PNG images using Aspose.Imaging in C#.
 * 2. When you want to improve the visual quality of captions on GIF frames by applying anti‑alias grid‑fit rendering before saving the animation.
 * 3. When you are creating a slideshow GIF where each slide requires a clear title or description overlaid on the image.
 * 4. When you must ensure that text drawn on GIF frames remains sharp on low‑resolution displays or browsers that render GIFs.
 * 5. When you are programmatically generating marketing GIFs with dynamic captions and need consistent text rendering across all frames.
 */
