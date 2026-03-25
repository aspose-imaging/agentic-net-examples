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
        // Hardcoded input CDR file path
        string inputPath = "input.cdr";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the CDR document
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Iterate through each page of the CDR document
            for (int i = 0; i < cdr.PageCount; i++)
            {
                // Retrieve the page and ensure its data is cached
                using (CdrImagePage page = (CdrImagePage)cdr.Pages[i])
                {
                    page.CacheData();

                    // Determine color depth information
                    int bitsPerPixel = page.BitsPerPixel;
                    ColorModes colorMode;
                    short channelsCount;
                    short channelBitsCount;

                    if (bitsPerPixel == 1)
                    {
                        colorMode = ColorModes.Bitmap;
                        channelsCount = 1;
                        channelBitsCount = 1;
                    }
                    else if (bitsPerPixel <= 8)
                    {
                        colorMode = ColorModes.Grayscale;
                        channelsCount = 1;
                        channelBitsCount = (short)bitsPerPixel;
                    }
                    else if (bitsPerPixel <= 24)
                    {
                        colorMode = ColorModes.Rgb;
                        channelsCount = 3;
                        channelBitsCount = (short)(bitsPerPixel / 3);
                    }
                    else // Assume 32‑bit (e.g., RGBA)
                    {
                        colorMode = ColorModes.Rgb;
                        channelsCount = 4;
                        channelBitsCount = (short)(bitsPerPixel / 4);
                    }

                    // Prepare output PSD file path
                    string outputPath = Path.Combine(".", $"page_{i + 1}.psd");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PSD save options
                    PsdOptions psdOptions = new PsdOptions
                    {
                        ColorMode = colorMode,
                        ChannelsCount = channelsCount,
                        ChannelBitsCount = channelBitsCount,
                        CompressionMethod = CompressionMethod.RLE
                    };

                    // Set vector rasterization options for the page
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = page.Width,
                        PageHeight = page.Height,
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    psdOptions.VectorRasterizationOptions = vectorOptions;

                    // Save the page as an individual PSD file
                    page.Save(outputPath, psdOptions);
                }
            }
        }
    }
}