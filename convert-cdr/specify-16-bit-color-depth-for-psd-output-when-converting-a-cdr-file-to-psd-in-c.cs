// HOW-TO: Convert CDR to PSD With 16‑Bit Color Depth In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.psd";

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
                var psdOptions = new PsdOptions
                {
                    ChannelBitsCount = (short)16,
                    ChannelsCount = (short)4,
                    ColorMode = ColorModes.Rgb,
                    CompressionMethod = CompressionMethod.Raw
                };

                if (image is VectorImage)
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                }

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
 * 1. When a designer needs to preserve high‑quality 16‑bit color information while converting CorelDRAW (CDR) artwork to Photoshop (PSD) files in a C# automation pipeline.
 * 2. When an application must batch‑process vector CDR files and output PSDs with four channels and raw compression for later editing in Photoshop.
 * 3. When a developer wants to ensure that rasterized vector graphics retain their original dimensions and color depth during CDR‑to‑PSD conversion using Aspose.Imaging.
 * 4. When integrating a file‑conversion service that requires creating PSD files with 16‑bit per channel depth to meet print‑ready specifications.
 * 5. When troubleshooting image‑format compatibility and need to verify that PSD files generated from CDR retain RGB mode and 16‑bit depth for accurate color reproduction.
 */
