using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.emf";
        string outputPath = "Output\\sample.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image emfImage = Image.Load(inputPath))
            {
                var gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true,
                    ColorResolution = 7,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = emfImage.Width,
                        PageHeight = emfImage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                emfImage.Save(outputPath, gifOptions);
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
 * 1. When a web application must display legacy vector graphics (EMF) in browsers that only support GIF, a developer can use this code to rasterize the EMF and generate a 256‑color GIF for fast loading.
 * 2. When an email marketing system needs to embed small animated or static images from EMF sources while keeping the email size under the typical 100 KB limit, the conversion to a palette‑limited GIF ensures compliance.
 * 3. When a Windows desktop utility creates thumbnail previews of EMF files for a file explorer, converting each thumbnail to a GIF with a fixed palette provides consistent color depth and reduces memory usage.
 * 4. When a reporting tool exports charts saved as EMF into a printable PDF that only accepts GIF images, this code transforms the vector charts into GIFs with controlled color resolution for reliable rendering.
 * 5. When a mobile app synchronizes design assets from a legacy CAD system and must store them as lightweight GIFs to minimize bandwidth, the developer can employ this routine to rasterize EMF files with a 256‑color palette.
 */