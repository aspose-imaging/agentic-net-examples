using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;
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

            string outputDir = "output_psd";
            Directory.CreateDirectory(outputDir);

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                for (int i = 0; i < cdr.PageCount; i++)
                {
                    using (CdrImagePage page = (CdrImagePage)cdr.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.psd");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PsdOptions psdOptions = new PsdOptions
                        {
                            CompressionMethod = CompressionMethod.RLE,
                            ChannelBitsCount = (short)page.BitsPerPixel,
                            ChannelsCount = (short)(page.BitsPerPixel / 8),
                            ColorMode = ColorModes.Rgb,
                            Version = 6,
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                PageWidth = page.Width,
                                PageHeight = page.Height
                            }
                        };

                        page.Save(outputPath, psdOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}