// HOW-TO: Convert Multi‑Page CDR to Separate PSD Files with Color Depth in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (var pageObj in cdr.Pages)
                {
                    var page = (CdrImagePage)pageObj;
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.psd");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PsdOptions psdOptions = new PsdOptions
                    {
                        CompressionMethod = CompressionMethod.RLE,
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        }
                    };

                    int bpp = page.BitsPerPixel;
                    int channels = bpp == 32 ? 4 : (bpp == 8 ? 1 : 3);
                    psdOptions.ChannelsCount = (short)channels;
                    psdOptions.ChannelBitsCount = (short)(bpp / channels);
                    psdOptions.ColorMode = channels == 1 ? ColorModes.Grayscale : ColorModes.Rgb;

                    page.Save(outputPath, psdOptions);
                    pageIndex++;
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
 * 1. When you need to extract each page of a CorelDRAW (CDR) document as a high‑fidelity Photoshop (PSD) file for further editing in Photoshop.
 * 2. When an automated workflow must convert multi‑page CDR designs into separate PSD files while preserving the original bits‑per‑pixel color information.
 * 3. When a batch process has to generate PSD assets from a library of CDR files for a print‑ready pipeline without losing grayscale or RGB color modes.
 * 4. When integrating Aspose.Imaging in a C# application to rasterize vector pages of a CDR into PSD files with RLE compression for reduced file size.
 * 5. When a developer wants to programmatically split a multi‑page CDR into individual PSD files, maintaining the exact color depth and channel count for each page.
 */
