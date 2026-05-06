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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.CompressionMethod = CompressionMethod.RLE;
            options.ChannelBitsCount = (short)8;
            options.ChannelsCount = (short)1;
            options.Version = 6;

            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                byte v = (byte)i;
                paletteColors[i] = Aspose.Imaging.Color.FromArgb(v, v, v);
            }
            options.Palette = new Aspose.Imaging.ColorPalette(paletteColors);

            int width = 200;
            int height = 200;

            using (Image canvas = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}