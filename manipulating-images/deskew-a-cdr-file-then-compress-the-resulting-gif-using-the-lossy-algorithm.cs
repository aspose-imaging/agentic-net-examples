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
        try
        {
            string inputPath = @"C:\Images\input.cdr";
            string outputPath = @"C:\Images\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };

                cdr.Save(outputPath, gifOptions);
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
 * 1. When a marketing automation system receives scanned CorelDRAW brochures that are slightly tilted, a developer can use Aspose.Imaging for .NET to deskew the CDR files and export them as smaller lossy GIFs for fast email distribution.
 * 2. When an e‑learning platform needs to display legacy vector illustrations on low‑bandwidth mobile devices, a developer can straighten the original CDR artwork and compress it into a lossy GIF to reduce file size while preserving visual fidelity.
 * 3. When a document management workflow must archive design assets as web‑ready images, a developer can automatically correct the orientation of each CDR page and save it as a lossy GIF to meet storage quotas.
 * 4. When a batch‑processing script prepares product catalogs for online catalogs, a developer can deskew the CorelDRAW drawings and apply lossy GIF compression to ensure quick page loads on the storefront.
 * 5. When a digital signage system imports vector graphics from CorelDRAW and needs them in a lightweight format, a developer can use the code to straighten the images and generate lossy GIFs that load instantly on the display hardware.
 */