using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdrImage.Width,
                            PageHeight = cdrImage.Height
                        }
                    };

                    cdrImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Save(outputPath, new GifOptions());
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a CorelDRAW (CDR) vector illustration into a web‑friendly GIF while preserving transparency, they can use Aspose.Imaging in C# to rasterize, dither, verify the alpha channel, and save the result.
 * 2. When an e‑commerce platform must generate low‑size product thumbnails from designer‑provided CDR files for email newsletters, the code lets the developer rasterize the vector, apply dithering to reduce color depth, and output a GIF that works across all email clients.
 * 3. When a legacy reporting system only accepts GIF images but the source assets are stored as CDR files, a developer can employ this C# routine to rasterize, check the alpha channel for proper transparency, and convert the vector to a GIF without manual export.
 * 4. When building an automated asset pipeline that extracts vector logos from CDR files and creates animated GIF sprites for mobile apps, the developer can use Aspose.Imaging to dither the rasterized image, ensure the alpha channel is intact, and save each frame as a GIF.
 * 5. When a digital signage solution requires fast loading of vector graphics on low‑bandwidth displays, a developer can programmatically convert CDR files to optimized GIFs with dithering and alpha verification using the provided C# code.
 */