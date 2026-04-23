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
        string inputFolder = @"C:\InputFrames";
        string fontFolder = @"C:\Fonts";
        string outputPath = @"C:\Output\animated.gif";

        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Folder not found: {inputFolder}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var frameFiles = Directory.GetFiles(inputFolder);
            if (frameFiles.Length == 0)
            {
                Console.Error.WriteLine("No frame files found.");
                return;
            }

            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource((args) =>
            {
                var fonts = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                if (args.Length > 0)
                {
                    string fontsPath = args[0]?.ToString() ?? string.Empty;
                    if (Directory.Exists(fontsPath))
                    {
                        foreach (var fontFile in Directory.GetFiles(fontsPath))
                        {
                            byte[] data = File.ReadAllBytes(fontFile);
                            string name = Path.GetFileNameWithoutExtension(fontFile);
                            fonts.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                }
                return fonts.ToArray();
            }, fontFolder);

            GifFrameBlock firstBlock = null;
            var additionalBlocks = new List<GifFrameBlock>();

            foreach (var filePath in frameFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(filePath, loadOptions))
                {
                    var block = new GifFrameBlock(raster);

                    var graphics = new Graphics(block);
                    using (var brush = new SolidBrush(Color.Yellow))
                    {
                        var font = new Font("Arial", 20);
                        graphics.DrawString("Sample Text", font, brush, new PointF(10, 10));
                    }

                    if (firstBlock == null)
                    {
                        firstBlock = block;
                    }
                    else
                    {
                        additionalBlocks.Add(block);
                    }
                }
            }

            if (firstBlock == null)
            {
                Console.Error.WriteLine("No valid frames to create GIF.");
                return;
            }

            using (var gifImage = new GifImage(firstBlock))
            {
                foreach (var blk in additionalBlocks)
                {
                    gifImage.AddBlock(blk);
                }

                gifImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}