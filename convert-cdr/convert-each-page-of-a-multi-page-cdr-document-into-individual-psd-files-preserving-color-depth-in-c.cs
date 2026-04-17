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
        string inputPath = "sample.cdr";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Output directory for PSD pages
        string outputDir = "output";
        Directory.CreateDirectory(outputDir);

        // Load the multi‑page CDR document
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            int pageCount = cdr.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                using (CdrImagePage page = (CdrImagePage)cdr.Pages[i])
                {
                    page.CacheData(); // optional caching

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.psd");
                    // Ensure the directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Prepare PSD save options preserving color depth
                    PsdOptions psdOptions = new PsdOptions
                    {
                        CompressionMethod = CompressionMethod.RLE,
                        Version = 6
                    };

                    int bitsPerPixel = page.BitsPerPixel;          // total bits per pixel
                    short channelBits = 8;                         // typical bits per channel
                    short channels = (short)(bitsPerPixel / channelBits);
                    if (channels == 0) channels = 1;               // fallback for unexpected values

                    psdOptions.ChannelBitsCount = channelBits;
                    psdOptions.ChannelsCount = channels;
                    psdOptions.ColorMode = (channels == 1) ? ColorModes.Grayscale : ColorModes.Rgb;

                    // Save the page as an individual PSD file
                    page.Save(outputPath, psdOptions);
                }
            }
        }
    }
}