using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = (short)8;
            psdOptions.ChannelsCount = (short)1;
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(psdOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawEllipse(new Pen(Color.Blue, 5), new Rectangle(100, 100, 300, 200));
                image.Save();
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
 * 1. When a developer needs to generate a PSD file with an indexed color palette and overlay an ellipse for a quick mock‑up of a logo or UI element.
 * 2. When creating automated batch scripts that produce layered Photoshop files for print‑ready assets while keeping file size low using RLE compression and a limited palette.
 * 3. When building a web service that returns a PSD thumbnail with a highlighted elliptical region to indicate a selected area in a photo‑editing workflow.
 * 4. When writing unit tests for image‑processing pipelines that require a known PSD canvas with a blue ellipse to verify drawing and color‑index handling.
 * 5. When integrating Aspose.Imaging into a C# desktop application that must export vector‑style shapes into an indexed PSD for legacy Photoshop compatibility.
 */