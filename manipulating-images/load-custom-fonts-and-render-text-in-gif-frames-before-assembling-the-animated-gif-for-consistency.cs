// HOW-TO: Load Custom Fonts and Render Text on GIF Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputImagePath = "input.png";
            string fontFolderPath = "fonts";
            string outputGifPath = "output.gif";

            // Input file existence check
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            // Load image with custom fonts
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(GetFontSource, fontFolderPath);
            using (RasterImage baseImage = (RasterImage)Image.Load(inputImagePath, loadOptions))
            {
                // Create first GIF frame from the base image
                using (GifFrameBlock firstBlock = new GifFrameBlock(baseImage))
                using (GifImage gif = new GifImage(firstBlock))
                {
                    // Define text to render on each frame
                    string[] texts = { "Frame 1", "Frame 2", "Frame 3", "Frame 4", "Frame 5" };
                    // Use first custom font name (assumes at least one font is loaded)
                    string fontName = "CustomFont";
                    // Font size
                    float fontSize = 24f;
                    // Text color
                    var textBrush = new SolidBrush(Color.Yellow);

                    for (int i = 0; i < texts.Length; i++)
                    {
                        // Create a new frame based on the base image
                        using (GifFrameBlock frameBlock = new GifFrameBlock(baseImage))
                        {
                            // Draw text onto the frame
                            var graphics = new Graphics(frameBlock);
                            var font = new Font(fontName, fontSize);
                            graphics.DrawString(texts[i], font, textBrush, new PointF(10, 10));

                            // Add the frame to the GIF
                            gif.AddBlock(frameBlock);
                        }
                    }

                    // Save the animated GIF
                    gif.Save(outputGifPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Custom font source provider
    private static Aspose.Imaging.CustomFontHandler.CustomFontData[] GetFontSource(params object[] args)
    {
        string fontsPath = string.Empty;
        if (args.Length > 0 && args[0] != null)
        {
            fontsPath = args[0].ToString();
        }

        var fontDataList = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
        if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
        {
            foreach (var fontFile in Directory.GetFiles(fontsPath))
            {
                string fontName = Path.GetFileNameWithoutExtension(fontFile);
                byte[] fontBytes = File.ReadAllBytes(fontFile);
                fontDataList.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(fontName, fontBytes));
            }
        }

        return fontDataList.ToArray();
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add brand‑specific typography to each frame of an animated GIF generated from a PNG template.
 * 2. When you want to create a multilingual animated banner where each frame displays localized text using custom font files.
 * 3. When you must ensure consistent font rendering across different servers by loading fonts from a dedicated folder before drawing text on GIF frames.
 * 4. When you are building a meme generator that overlays custom‑styled captions onto a sequence of GIF frames in a .NET application.
 * 5. When you need to programmatically produce an animated tutorial where step numbers are drawn on each frame using a specific TrueType font.
 */
