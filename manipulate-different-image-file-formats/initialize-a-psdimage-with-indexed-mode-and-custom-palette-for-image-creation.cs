using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);

            PsdOptions options = new PsdOptions
            {
                Source = source,
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed,
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                Version = 6,
                Palette = new ColorPalette(new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green,
                    Aspose.Imaging.Color.Blue,
                    Aspose.Imaging.Color.Black,
                    Aspose.Imaging.Color.White
                }),
                ChannelsCount = (short)1,
                ChannelBitsCount = (short)8
            };

            int canvasWidth = 200;
            int canvasHeight = 200;

            using (Image canvas = Image.Create(options, canvasWidth, canvasHeight))
            {
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}