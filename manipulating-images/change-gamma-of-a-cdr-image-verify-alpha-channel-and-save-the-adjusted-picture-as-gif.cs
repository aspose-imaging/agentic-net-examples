using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR image
        using (Image cdrImage = Image.Load(inputPath))
        {
            CdrImage cdr = (CdrImage)cdrImage;

            // Prepare GIF options with vector rasterization settings
            GifOptions gifOptions = new GifOptions
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                }
            };

            // Create a raster GIF canvas from the CDR vector image
            using (Image rasterImage = Image.Create(gifOptions, cdr.Width, cdr.Height))
            {
                GifImage gif = (GifImage)rasterImage;

                // Adjust gamma (example value 2.2)
                gif.AdjustGamma(2.2f);

                // Verify presence of alpha channel
                bool hasAlpha = gif.HasAlpha;
                Console.WriteLine($"Alpha channel present: {hasAlpha}");

                // Save the GIF (output path already bound via FileCreateSource)
                gif.Save();
            }
        }
    }
}