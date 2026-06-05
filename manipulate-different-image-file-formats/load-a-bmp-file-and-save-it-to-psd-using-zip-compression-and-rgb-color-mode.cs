using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output/output.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert legacy BMP graphics into Photoshop‑compatible PSD files with lossless RLE compression and RGB color mode for further editing in a .NET application.
 * 2. When an automated build process must generate PSD assets from BMP source files to maintain color fidelity while reducing file size using Aspose.Imaging in C#.
 * 3. When a content management system requires on‑the‑fly conversion of uploaded BMP images to PSD format with RGB channels for designers to work on in Adobe Photoshop.
 * 4. When a batch‑processing tool has to migrate a collection of BMP icons into PSD files with RLE compression to prepare them for high‑resolution print workflows.
 * 5. When a Windows service needs to read BMP files, apply the RGB color mode, and save them as compressed PSD files for archival storage using Aspose.Imaging for .NET.
 */