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
        string outputPath = @"C:\temp\concentric_circles.psd";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Color[] paletteColors = new Color[]
        {
            Color.Black,
            Color.White,
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow,
            Color.Cyan,
            Color.Magenta
        };

        PsdOptions psdOptions = new PsdOptions();
        psdOptions.Source = new FileCreateSource(outputPath, false);
        psdOptions.ColorMode = ColorModes.Indexed;
        psdOptions.Palette = new ColorPalette(paletteColors);
        psdOptions.ChannelsCount = (short)1;
        psdOptions.ChannelBitsCount = (short)8;
        psdOptions.CompressionMethod = CompressionMethod.RLE;

        int width = 500;
        int height = 500;

        using (Image image = Image.Create(psdOptions, width, height))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            int centerX = width / 2;
            int centerY = height / 2;
            int maxRadius = Math.Min(width, height) / 2 - 10;
            int step = 20;

            for (int radius = maxRadius; radius > 0; radius -= step)
            {
                Color circleColor = paletteColors[(radius / step) % paletteColors.Length];
                Pen pen = new Pen(circleColor, 2);
                Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                graphics.DrawEllipse(pen, rect);
            }

            image.Save();
        }
    }
}