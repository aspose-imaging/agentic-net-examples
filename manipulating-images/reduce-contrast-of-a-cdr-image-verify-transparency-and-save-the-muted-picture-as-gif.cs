using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Prepare GIF options with vector rasterization settings
                GifOptions rasterOptions = new GifOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                // Rasterize CDR to GIF in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, rasterOptions);
                    ms.Position = 0;

                    // Load the rasterized GIF
                    using (GifImage gif = (GifImage)Image.Load(ms))
                    {
                        // Reduce contrast (negative value lowers contrast)
                        gif.AdjustContrast(-30f);

                        // Verify transparency
                        bool hasTransparency = gif.HasTransparentColor;
                        Console.WriteLine($"Has transparency: {hasTransparency}");

                        // Save the final GIF
                        gif.Save(outputPath, new GifOptions());
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