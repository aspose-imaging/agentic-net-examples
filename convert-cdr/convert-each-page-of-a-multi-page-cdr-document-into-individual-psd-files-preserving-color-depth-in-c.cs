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
                int pageIndex = 0;
                foreach (Image img in cdr.Pages)
                {
                    using (CdrImagePage page = (CdrImagePage)img)
                    {
                        string outputPath = Path.Combine("output", $"page_{pageIndex}.psd");
                        string outputDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrWhiteSpace(outputDir))
                        {
                            Directory.CreateDirectory(outputDir);
                        }

                        PsdOptions psdOptions = new PsdOptions
                        {
                            CompressionMethod = CompressionMethod.RLE,
                            Version = 6,
                            ColorMode = page.BitsPerPixel <= 8 ? ColorModes.Grayscale : ColorModes.Rgb
                        };

                        int bitsPerPixel = page.BitsPerPixel;
                        int channels = bitsPerPixel == 32 ? 4 : (bitsPerPixel == 24 ? 3 : 1);
                        psdOptions.ChannelsCount = (short)channels;
                        psdOptions.ChannelBitsCount = (short)(bitsPerPixel / channels);

                        VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        psdOptions.VectorRasterizationOptions = vectorOptions;

                        page.Save(outputPath, psdOptions);
                    }

                    pageIndex++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}