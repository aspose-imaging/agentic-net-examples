using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    GifOptions options = new GifOptions
                    {
                        ColorResolution = 7,
                        DoPaletteCorrection = true,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    cdr.Save(outputPath, options);
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
 * 1. When a developer needs to batch‑convert a collection of CorelDRAW (CDR) vector files into web‑friendly 256‑color GIF images for faster page loads.
 * 2. When an e‑commerce platform must automatically generate low‑size product thumbnails from designer‑provided CDR assets during nightly processing.
 * 3. When a digital archiving system has to preserve legacy CDR illustrations as GIFs with a fixed palette to ensure compatibility with older viewing software.
 * 4. When a marketing automation tool has to transform multiple CDR logos into animated GIFs with a white background for email campaigns.
 * 5. When a print‑to‑screen workflow requires converting CDR pages to GIFs with exact dimensions and color correction before sending them to a remote display server.
 */