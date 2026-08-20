// HOW-TO: Convert EPS to 16‑Bit PSD for High Quality Editing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.eps";
            string outputPath = "output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options for 16‑bit per channel
                var psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 16,                     // 16 bits per channel
                    ChannelsCount = 4,                         // RGBA
                    ColorMode = ColorModes.Rgb,                // RGB color mode
                    CompressionMethod = CompressionMethod.Raw, // No compression
                    Version = 6                                // PSD version 6
                };

                // Save as PSD
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
 * 1. When you need to import vector EPS artwork into Photoshop for detailed retouching while preserving 16‑bit color depth.
 * 2. When an automated .NET pipeline must transform EPS logos into PSD files for further layer‑based editing.
 * 3. When a print‑ready workflow requires converting EPS designs to PSD with RGBA channels and raw compression to maintain image fidelity.
 * 4. When a digital asset management system stores EPS files but needs to generate PSD previews with 16‑bit per channel for high‑resolution displays.
 * 5. When a batch conversion tool in C# must ensure the output PSD uses version 6 and no compression for compatibility with legacy Photoshop versions.
 */
