// HOW-TO: Deskew CDR File and Save as Compressed GIF in C# (Aspose.Imaging for .NET)
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

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
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
 * 1. When you need to automatically straighten scanned CorelDRAW (CDR) drawings before delivering them as lightweight GIFs for web preview.
 * 2. When a batch process must convert legacy CDR artwork into lossy GIFs to reduce bandwidth while preserving visual fidelity.
 * 3. When an e‑commerce platform requires deskewed product illustrations from CDR files and wants them compressed as GIFs for faster page loads.
 * 4. When a document management system needs to normalize the orientation of CDR pages and store them in a small GIF format for archival.
 * 5. When a mobile app must import CDR assets, correct their tilt, and output compressed GIFs to fit limited storage constraints.
 */
