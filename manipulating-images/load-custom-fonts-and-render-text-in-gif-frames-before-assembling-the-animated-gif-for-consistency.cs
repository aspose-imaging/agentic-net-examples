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
            string inputImagePath = "C:\\InputFrames\\frame1.png";
            string fontFolderPath = "C:\\Fonts";
            string outputGifPath = "C:\\Output\\animated.gif";

            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((object[] args) =>
            {
                var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            string fontName = Path.GetFileNameWithoutExtension(fontFile);
                            byte[] fontData = File.ReadAllBytes(fontFile);
                            list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontData));
                        }
                    }
                }
                return list.ToArray();
            }, fontFolderPath);

            using (var raster = (RasterImage)Image.Load(inputImagePath, loadOptions))
            {
                using (var brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    Graphics graphics = new Graphics(raster);
                    string text = "Hello, World!";
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("CustomFont", 24);
                    graphics.DrawString(text, font, brush, new Point(10, 10));
                }

                GifFrameBlock firstBlock = new GifFrameBlock(raster);
                using (var gifImage = new GifImage(firstBlock))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        using (var frameRaster = (RasterImage)Image.Load(inputImagePath, loadOptions))
                        {
                            using (var frameBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(255, i * 50, 0, 0)))
                            {
                                Graphics frameGraphics = new Graphics(frameRaster);
                                Aspose.Imaging.Font frameFont = new Aspose.Imaging.Font("CustomFont", 24);
                                frameGraphics.DrawString($"Frame {i + 1}", frameFont, frameBrush, new Point(10, 30));
                            }

                            GifFrameBlock block = new GifFrameBlock(frameRaster);
                            gifImage.AddBlock(block);
                        }
                    }

                    GifOptions gifOptions = new GifOptions
                    {
                        LoopsCount = 0
                    };
                    gifImage.Save(outputGifPath, gifOptions);
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
 * 1. When creating an animated promotional banner where each frame must display brand‑specific typography, a developer can load custom fonts and draw text onto PNG frames before assembling them into a GIF using Aspose.Imaging for .NET.
 * 2. When generating localized error‑message animations for a desktop application, developers need to embed language‑specific fonts into each GIF frame to ensure the text renders correctly on any system.
 * 3. When building a meme generator that overlays user‑provided captions in a unique handwritten font onto a sequence of images, loading the custom font and rendering the text on each frame guarantees consistent appearance in the final animated GIF.
 * 4. When producing a step‑by‑step tutorial GIF for a software product, developers can use the code to add numbered instructions with a corporate font to each frame, ensuring the text style matches the product’s branding.
 * 5. When automating the creation of animated social‑media stickers that include stylized text, loading custom font files and drawing the text onto raster images before GIF assembly prevents fallback to default system fonts across different platforms.
 */