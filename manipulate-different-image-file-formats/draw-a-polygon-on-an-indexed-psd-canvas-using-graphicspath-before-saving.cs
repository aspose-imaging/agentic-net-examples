using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\indexed_output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelsCount = (short)1;
            psdOptions.ChannelBitsCount = (short)8;
            psdOptions.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });

            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
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
 * 1. When a developer needs to generate a lightweight PSD thumbnail with a simple polygon overlay for a web‑based asset manager, using Aspose.Imaging’s indexed color mode to keep the file size minimal.
 * 2. When creating batch‑processed print‑ready PSD files that employ an indexed palette and require programmatic addition of vector shapes like polygons for cut‑line markings.
 * 3. When building a C# utility that converts legacy indexed‑color Photoshop files into modern assets while annotating them with a polygonal region to highlight areas of interest.
 * 4. When automating UI mock‑up production where the background is an indexed PSD and a polygon drawn via GraphicsPath represents button boundaries before saving.
 * 5. When developing a game asset pipeline that stores sprite outlines as polygons inside an indexed PSD to maintain a small palette and ensure fast loading in the engine.
 */