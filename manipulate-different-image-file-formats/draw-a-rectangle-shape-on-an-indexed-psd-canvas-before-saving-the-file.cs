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
        string outputPath = @"C:\temp\output.psd";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        Source source = new FileCreateSource(outputPath, false);

        PsdOptions psdOptions = new PsdOptions();
        psdOptions.Source = source;
        psdOptions.ColorMode = ColorModes.Indexed;
        psdOptions.CompressionMethod = CompressionMethod.RLE;
        psdOptions.ChannelsCount = (short)1;
        psdOptions.ChannelBitsCount = (short)8;
        psdOptions.Version = 6;

        Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
        {
            Aspose.Imaging.Color.Black,
            Aspose.Imaging.Color.White,
            Aspose.Imaging.Color.Red,
            Aspose.Imaging.Color.Green,
            Aspose.Imaging.Color.Blue
        };
        psdOptions.Palette = new ColorPalette(paletteColors);

        using (RasterImage canvas = (RasterImage)Image.Create(psdOptions, 400, 300))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.DrawRectangle(
                new Pen(Aspose.Imaging.Color.Blue, 3),
                new Rectangle(50, 50, 200, 150));
            canvas.Save();
        }
    }
}