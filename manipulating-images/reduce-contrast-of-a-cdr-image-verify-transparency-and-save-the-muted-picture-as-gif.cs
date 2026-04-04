using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_muted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Render the first page of the CDR to a raster image (PNG in memory)
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Save the first page as PNG to the memory stream
                cdrImage.Pages[0].Save(rasterStream, new PngOptions());
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the raster image as a GIF image (still in memory)
                using (GifImage gifImage = (GifImage)Image.Load(rasterStream))
                {
                    // Reduce contrast (negative value reduces contrast)
                    gifImage.AdjustContrast(-30f);

                    // Verify if the image contains any transparent pixels
                    bool hasTransparency = false;
                    for (int y = 0; y < gifImage.Height && !hasTransparency; y++)
                    {
                        for (int x = 0; x < gifImage.Width; x++)
                        {
                            int argb = gifImage.GetArgb32Pixel(x, y);
                            byte alpha = (byte)(argb >> 24);
                            if (alpha < 255)
                            {
                                hasTransparency = true;
                                break;
                            }
                        }
                    }

                    Console.WriteLine($"Transparency detected: {hasTransparency}");

                    // Save the muted GIF to the output path
                    gifImage.Save(outputPath, new GifOptions());
                }
            }
        }
    }
}