// HOW-TO: Set Text Rendering Hint for Animated GIF Captions in C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output.gif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifFrameBlock firstBlock = new GifFrameBlock(200, 100))
            {
                Graphics graphics = new Graphics(firstBlock);
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    Font font = new Font("Arial", 20);
                    graphics.DrawString("First Frame", font, brush, new PointF(10, 40));
                }

                using (GifImage gifImage = new GifImage(firstBlock))
                {
                    using (GifFrameBlock secondBlock = new GifFrameBlock(200, 100))
                    {
                        Graphics graphics2 = new Graphics(secondBlock);
                        using (SolidBrush brush2 = new SolidBrush(Color.Cyan))
                        {
                            Font font2 = new Font("Arial", 20);
                            graphics2.DrawString("Second Frame", font2, brush2, new PointF(10, 40));
                        }
                        gifImage.AddBlock(secondBlock);
                    }

                    GifOptions gifOptions = new GifOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                        }
                    };

                    gifImage.Save(outputPath, gifOptions);
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
 * 1. When you need to generate an animated GIF with readable text captions using Aspose.Imaging in a C# application.
 * 2. When creating a product‑image slideshow where each GIF frame contains a label and the text must stay sharp on low‑resolution output.
 * 3. When building a reporting tool that exports animated charts as GIFs and requires anti‑aliased text for better visual quality.
 * 4. When adding dynamic watermarks to GIFs for a social‑media sharing feature and want the watermark text to remain clear.
 * 5. When automating instructional GIFs with step‑by‑step instructions and need consistent text rendering across all frames.
 */
