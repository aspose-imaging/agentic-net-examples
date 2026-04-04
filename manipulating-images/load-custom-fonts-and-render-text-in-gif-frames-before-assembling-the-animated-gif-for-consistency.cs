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
    static void Main()
    {
        // Hardcoded input paths
        string fontFolderPath = "fonts";
        string[] framePaths = { "frame1.png", "frame2.png", "frame3.png" };
        string outputPath = "output.gif";

        // Verify font folder
        if (!Directory.Exists(fontFolderPath))
        {
            Console.Error.WriteLine($"Folder not found: {fontFolderPath}");
            return;
        }

        // Verify each frame file
        foreach (var path in framePaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Prepare LoadOptions with custom fonts
        var loadOptions = new LoadOptions();
        loadOptions.AddCustomFontSource((args) =>
        {
            string fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
            var list = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
            if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
            {
                foreach (var fontFile in Directory.GetFiles(fontsPath))
                {
                    byte[] fontBytes = File.ReadAllBytes(fontFile);
                    string fontName = Path.GetFileNameWithoutExtension(fontFile);
                    list.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
                }
            }
            return list.ToArray();
        }, fontFolderPath);

        // List to hold GIF frame blocks
        var gifBlocks = new List<GifFrameBlock>();

        // Load each frame, render text, and convert to GifFrameBlock
        foreach (var path in framePaths)
        {
            using (var raster = (RasterImage)Image.Load(path, loadOptions))
            {
                // Create a block from the raster image
                var block = new GifFrameBlock(raster);

                // Draw text onto the block
                var graphics = new Graphics(block);
                using (var brush = new SolidBrush(Color.Yellow))
                {
                    // Use a custom font (fallback to default if not found)
                    var font = new Font("CustomFontName", 20);
                    graphics.DrawString("Sample Text", font, brush, new PointF(10, 10));
                }

                gifBlocks.Add(block);
            }
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Assemble GIF
        using (var gifImage = new GifImage(gifBlocks[0]))
        {
            for (int i = 1; i < gifBlocks.Count; i++)
            {
                gifImage.AddBlock(gifBlocks[i]);
            }

            gifImage.Save(outputPath);
        }
    }
}