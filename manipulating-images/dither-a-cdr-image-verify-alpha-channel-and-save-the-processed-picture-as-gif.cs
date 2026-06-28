using System;
using System.IO;
using Aspose.Imaging;
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

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var gifOptions = new GifOptions();
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
 * 1. When a designer needs to embed a CorelDRAW (CDR) illustration into a web page that only supports GIF images, a developer can use this code to rasterize the CDR, ensure the alpha channel is handled, and output a GIF.
 * 2. When an e‑learning platform must convert legacy CDR assets into animated GIFs for lightweight delivery on low‑bandwidth devices, this snippet automates the rasterization and format conversion in C#.
 * 3. When a batch‑processing tool has to verify that a CDR file’s transparency is preserved before generating a GIF thumbnail, the code loads the CDR, checks the alpha channel via rasterization, and saves the result as a GIF.
 * 4. When a content‑management system receives user‑uploaded CDR files and needs to store them as GIFs for preview thumbnails, developers can employ this routine to rasterize, dither, and convert the image in a single pass.
 * 5. When a Windows desktop application must programmatically convert vector CDR artwork into a GIF with proper dithering for printing proofs, this example shows how to use Aspose.Imaging’s CdrRasterizationOptions and GifOptions in C#.
 */