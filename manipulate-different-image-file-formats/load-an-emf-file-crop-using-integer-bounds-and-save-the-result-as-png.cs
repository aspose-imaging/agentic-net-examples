using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                Rectangle cropRect = new Rectangle(10, 10, 200, 150);
                emfImage.Crop(cropRect);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                emfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract a specific region from a vector‑based EMF diagram and deliver it as a raster PNG for web display.
 * 2. When an application must convert legacy Windows Metafile graphics into PNG thumbnails while trimming unnecessary margins.
 * 3. When a reporting tool has to generate printable PNG snippets from EMF charts by cropping to the chart area.
 * 4. When a batch‑processing script automates the preparation of EMF icons for mobile apps by cropping and saving them as PNG files.
 * 5. When a document‑conversion service requires isolating a portion of an EMF illustration and storing it as a PNG image for inclusion in PDF files.
 */