using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var saveOptions = new PngOptions();

                if (image is IMultipageImage)
                {
                    image.Save(outputPath, saveOptions);
                }
                else if (image is RasterImage)
                {
                    image.Save(outputPath, saveOptions);
                }
                else
                {
                    image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to batch‑process a multi‑page PNG (such as a scanned brochure) and add a 3×3 emboss effect to each page before publishing it online.
 * 2. When an application must automatically enhance every frame of an animated PNG with a subtle emboss filter to give a tactile look for a game UI.
 * 3. When a document‑management system converts multi‑page PNG invoices into embossed images for watermark‑style visual verification.
 * 4. When a reporting tool generates multi‑page PNG charts and wants to apply the Emboss3x3 filter to all pages to improve visual depth in printed reports.
 * 5. When a web service receives multi‑page PNG assets from users and needs to apply a consistent emboss filter to every page before storing them in a cloud gallery.
 */