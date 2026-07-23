using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                using (EmfImage emfImage = new EmfImage(tiffImage.Width, tiffImage.Height))
                {
                    Graphics graphics = new Graphics(emfImage);
                    graphics.DrawImage(tiffImage, new Rectangle(0, 0, emfImage.Width, emfImage.Height));

                    PngOptions pngOptions = new PngOptions();
                    emfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert scanned TIFF documents that contain embedded EMF text into high‑resolution PNG images for web preview without losing vector quality.
 * 2. When an application must generate thumbnail PNGs from multi‑page TIFF files while preserving the original EMF‑based annotations as scalable graphics.
 * 3. When a reporting tool has to embed TIFF‑based charts with EMF labels into PNG charts for inclusion in PDF or email attachments.
 * 4. When a legacy system stores printable forms as TIFF files with EMF text and the new system requires PNG assets for mobile display.
 * 5. When a batch‑processing service automates the conversion of TIFF images containing vector‑based watermarks (EMF) into PNG files for archival storage.
 */