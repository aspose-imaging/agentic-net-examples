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
            // Hardcoded paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";
            string fontFolderPath = "fonts";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare custom font source
            var loadOptions = new LoadOptions();
            loadOptions.AddCustomFontSource(
                args =>
                {
                    var fontsPath = args.Length > 0 ? args[0]?.ToString() : string.Empty;
                    var result = new List<Aspose.Imaging.CustomFontHandler.CustomFontData>();
                    if (!string.IsNullOrEmpty(fontsPath) && Directory.Exists(fontsPath))
                    {
                        foreach (var file in Directory.GetFiles(fontsPath))
                        {
                            var data = File.ReadAllBytes(file);
                            var name = Path.GetFileNameWithoutExtension(file);
                            result.Add(new Aspose.Imaging.CustomFontHandler.CustomFontData(name, data));
                        }
                    }
                    return result.ToArray();
                },
                fontFolderPath);

            // Load GIF with custom fonts
            using (var gif = (GifImage)Image.Load(inputPath, loadOptions))
            {
                // Iterate through each frame and draw text
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    var graphics = new Graphics(gif.ActiveFrame);

                    using (var brush = new SolidBrush(Color.Yellow))
                    {
                        // Use a custom font (fallback to default if not found)
                        var font = new Font("CustomFont", 20);
                        graphics.DrawString($"Frame {i + 1}", font, brush, new Point(10, 10));
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified GIF
                gif.Save(outputPath);
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
 * 1. When creating an animated GIF banner that must use a corporate typeface not installed on the server, a developer can load custom fonts and render text on each frame with Aspose.Imaging for .NET.
 * 2. When generating personalized meme GIFs where the caption uses a unique hand‑drawn font, this code lets the C# application embed the font files and draw the text consistently across all frames.
 * 3. When building a marketing email that includes an animated GIF with product names displayed in a brand‑specific font, developers can use this approach to ensure the font appears correctly on every recipient’s device.
 * 4. When converting a series of chart images into an animated GIF and adding axis labels in a custom scientific font, the code demonstrates how to load the font folder and draw the labels on each frame before saving.
 * 5. When developing a game UI that shows animated tutorial tips in a stylized font, the snippet shows how to load custom font resources and render the tip text onto each GIF frame for smooth playback.
 */