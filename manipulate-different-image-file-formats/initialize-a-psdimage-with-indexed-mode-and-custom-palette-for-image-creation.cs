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
            string outputPath = @"C:\Temp\output_indexed.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            Source source = new FileCreateSource(outputPath, false);

            PsdOptions options = new PsdOptions
            {
                Source = source,
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                ChannelsCount = (short)1,
                ChannelBitsCount = (short)8,
                Palette = new ColorPalette(new Color[]
                {
                    Color.Red,
                    Color.Green,
                    Color.Blue,
                    Color.White,
                    Color.Black
                })
            };

            using (var psd = Image.Create(options, width, height))
            {
                psd.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}