using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string fontFolderPath = "fonts";
            string inputPath1 = "frame1.png";
            string inputPath2 = "frame2.png";
            string outputPath = "output.gif";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with custom font source
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                {
                    foreach (var file in Directory.GetFiles(fontsPath))
                    {
                        byte[] data = File.ReadAllBytes(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                    }
                }
                return list.ToArray();
            }, fontFolderPath);

            // Load first frame and draw text
            using (RasterImage raster1 = (RasterImage)Image.Load(inputPath1, loadOptions))
            {
                using (GifFrameBlock block1 = new GifFrameBlock(raster1))
                {
                    Graphics graphics1 = new Graphics(block1);
                    SolidBrush brush1 = new SolidBrush(Color.Yellow);
                    Font font1 = new Font("Arial", 20);
                    graphics1.DrawString("First Frame", font1, brush1, new PointF(10, 10));

                    // Load second frame and draw text
                    using (RasterImage raster2 = (RasterImage)Image.Load(inputPath2, loadOptions))
                    {
                        using (GifFrameBlock block2 = new GifFrameBlock(raster2))
                        {
                            Graphics graphics2 = new Graphics(block2);
                            SolidBrush brush2 = new SolidBrush(Color.Cyan);
                            Font font2 = new Font("Arial", 20);
                            graphics2.DrawString("Second Frame", font2, brush2, new PointF(10, 10));

                            // Create GIF image and add frames
                            using (GifImage gifImage = new GifImage(block1))
                            {
                                gifImage.AddBlock(block2);
                                gifImage.Save(outputPath);
                            }
                        }
                    }
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
 * 1. When a developer needs to generate an animated GIF from multiple PNG frames and ensure that captions use a corporate brand font that is not installed on the server.
 * 2. When an e‑learning platform wants to add multilingual subtitles to each frame of a tutorial animation while keeping the text style consistent across all frames.
 * 3. When a marketing automation tool creates promotional GIFs on the fly and must embed product names in a custom script font that resides in a dedicated fonts folder.
 * 4. When a game developer produces sprite animations and wants to overlay score or status text using a pixel‑art font that is loaded at runtime rather than from the OS.
 * 5. When a reporting dashboard exports data visualizations as animated GIFs and needs to label each frame with dynamically generated timestamps using a specific custom font for regulatory compliance.
 */