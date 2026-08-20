// HOW-TO: Convert EPS to PSD with Alpha Channel Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\output.psd";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options to preserve transparency (RGBA)
                var psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 8,                     // 8 bits per channel
                    ChannelsCount = 4,                        // R, G, B, Alpha
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                    Version = 6                               // Default PSD version
                };

                // Save the image as PSD preserving the alpha channel
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
 * 1. When you need to import vector EPS artwork into Photoshop while keeping its transparent background for further editing.
 * 2. When an automated pipeline must convert EPS logos to PSD files for a design system without losing the alpha channel.
 * 3. When generating print‑ready PSD composites from EPS illustrations and you require the original transparency for layer masking.
 * 4. When migrating legacy EPS assets to PSD format in a C# application and must retain RGBA data for web publishing.
 * 5. When building a batch converter that processes multiple EPS files to PSD using Aspose.Imaging and must preserve transparency for downstream graphics workflows.
 */
