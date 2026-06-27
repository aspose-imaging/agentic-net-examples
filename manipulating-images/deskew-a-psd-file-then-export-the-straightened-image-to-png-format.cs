using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.NormalizeAngle(false, Color.White);
                }

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to automatically correct the tilt of scanned Photoshop PSD files before publishing them as web‑ready PNG images.
 * 2. When an e‑commerce platform must straighten product mockups stored in PSD format and convert them to PNG for fast browser display.
 * 3. When a digital archiving system processes legacy PSD artwork, removes skew using Aspose.Imaging’s NormalizeAngle, and saves the result as lossless PNG for long‑term storage.
 * 4. When a mobile app backend receives user‑uploaded PSD files, deskews the raster layer and outputs a PNG thumbnail for preview generation.
 * 5. When a print‑to‑web workflow requires batch‑processing of PSD designs, correcting their orientation and exporting them to PNG using C# and Aspose.Imaging.
 */