// HOW-TO: Reduce Contrast of CDR Image, Check Transparency and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;

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

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        raster.AdjustContrast(-0.5f);

                        bool hasTransparency = raster.HasAlpha;
                        Console.WriteLine($"Transparency present: {hasTransparency}");

                        GifOptions gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
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
 * 1. When you need to lower the contrast of a CorelDRAW (CDR) file before converting it to a web‑friendly GIF while preserving any alpha channel.
 * 2. When an application must verify whether a rasterized CDR image contains transparency before deciding how to handle the output format.
 * 3. When you want to programmatically convert a multi‑page CDR document to a single‑frame GIF after applying image‑processing adjustments in a .NET service.
 * 4. When you are building a batch‑processing tool that extracts CDR graphics, reduces their contrast for a muted visual style, and saves them as animated‑compatible GIFs.
 * 5. When you need to use Aspose.Imaging in C# to rasterize vector CDR content to PNG in memory, adjust its contrast, check the alpha flag, and directly output a GIF without creating intermediate files.
 */
