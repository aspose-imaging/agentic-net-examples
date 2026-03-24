using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputWebP = @"C:\Images\input.webp";
        string outputPng = @"C:\Images\output.png";
        string outputResizedWebP = @"C:\Images\resized.webp";
        string outputAnimatedWebP = @"C:\Images\animated.webp";

        // Validate input file existence
        if (!File.Exists(inputWebP))
        {
            Console.Error.WriteLine($"File not found: {inputWebP}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPng));
        Directory.CreateDirectory(Path.GetDirectoryName(outputResizedWebP));
        Directory.CreateDirectory(Path.GetDirectoryName(outputAnimatedWebP));

        // 1. Load WebP, resize, and save as PNG
        using (WebPImage webP = (WebPImage)Image.Load(inputWebP))
        {
            // Resize to double size using nearest neighbour resampling
            webP.Resize(webP.Width * 2, webP.Height * 2, ResizeType.NearestNeighbourResample);
            webP.Save(outputPng, new PngOptions());
        }

        // 2. Create a new WebP image from scratch, fill with solid color, and save
        WebPOptions createOptions = new WebPOptions
        {
            Lossless = true,
            Quality = 100f
        };
        using (WebPImage newWebP = new WebPImage(200, 200, createOptions))
        {
            // Fill the canvas with blue color
            Graphics graphics = new Graphics(newWebP);
            SolidBrush brush = new SolidBrush(Color.Blue);
            graphics.FillRectangle(brush, newWebP.Bounds);
            // Save the created WebP
            newWebP.Save(outputResizedWebP);
        }

        // 3. Create an animated WebP with simple frames
        WebPOptions animOptions = new WebPOptions
        {
            Lossless = true,
            Quality = 100f,
            AnimLoopCount = 0, // infinite loop
            AnimBackgroundColor = (uint)Color.White.ToArgb()
        };
        using (WebPImage animatedWebP = new WebPImage(100, 100, animOptions))
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush greenBrush = new SolidBrush(Color.Green);

            // Add 5 frames with a moving red circle
            for (int i = 0; i < 5; i++)
            {
                WebPFrameBlock frame = new WebPFrameBlock(100, 100);
                Graphics g = new Graphics(frame);
                int radius = 10 + i * 5;
                int centerX = 50;
                int centerY = 50;
                g.FillEllipse(redBrush, new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2));
                animatedWebP.AddBlock(frame);
            }

            // Add 5 frames with a moving green circle
            for (int i = 0; i < 5; i++)
            {
                WebPFrameBlock frame = new WebPFrameBlock(100, 100);
                Graphics g = new Graphics(frame);
                int radius = 10 + i * 5;
                int centerX = 50;
                int centerY = 50;
                g.FillEllipse(greenBrush, new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2));
                animatedWebP.AddBlock(frame);
            }

            // Save the animated WebP
            animatedWebP.Save(outputAnimatedWebP);
        }
    }
}