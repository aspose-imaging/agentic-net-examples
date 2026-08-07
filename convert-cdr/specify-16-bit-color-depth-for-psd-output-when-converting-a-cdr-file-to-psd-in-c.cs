using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
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

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                PsdOptions psdOptions = new PsdOptions();
                psdOptions.ChannelBitsCount = (short)16;
                psdOptions.ChannelsCount = (short)4;
                psdOptions.ColorMode = ColorModes.Rgb;
                psdOptions.CompressionMethod = CompressionMethod.Raw;
                psdOptions.Version = 6;

                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };

                cdr.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert CorelDRAW (CDR) artwork to a Photoshop (PSD) file while preserving 16‑bit per channel color depth for high‑fidelity printing.
 * 2. When a workflow requires batch processing of CDR files into PSD format with exact RGB color mode and four channels for downstream compositing in Adobe Photoshop.
 * 3. When an application must export vector graphics from a CDR document to a PSD using Aspose.Imaging’s VectorRasterizationOptions to maintain the original page dimensions and avoid loss of detail.
 * 4. When a graphics pipeline needs to generate PSD files with raw compression and PSD version 6 compatibility to ensure maximum compatibility with legacy Photoshop versions.
 * 5. When a .NET service has to validate the existence of source CDR files, create output directories, and handle exceptions while converting to 16‑bit PSD to integrate with automated publishing systems.
 */