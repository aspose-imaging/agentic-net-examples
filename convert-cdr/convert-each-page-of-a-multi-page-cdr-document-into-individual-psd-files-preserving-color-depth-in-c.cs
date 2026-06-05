using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                int pageCount = cdr.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    CdrImagePage page = (CdrImagePage)cdr.Pages[i];
                    page.CacheData();

                    string outputPath = $"page_{i + 1}.psd";

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PsdOptions psdOptions = new PsdOptions
                    {
                        ChannelBitsCount = (short)page.BitsPerPixel,
                        ChannelsCount = (short)(page.BitsPerPixel / 8),
                        CompressionMethod = CompressionMethod.RLE
                    };

                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = page.Width,
                        PageHeight = page.Height,
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    psdOptions.VectorRasterizationOptions = vectorOptions;

                    page.Save(outputPath, psdOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}