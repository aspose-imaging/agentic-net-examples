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
            string inputPath = "sample.eps";
            string outputPath = "sample.psd";

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
                // Configure PSD options to keep transparency (RGBA)
                var psdOptions = new PsdOptions
                {
                    ColorMode = ColorModes.Rgb,          // Use RGB color mode
                    ChannelsCount = 4,                  // R, G, B, Alpha
                    ChannelBitsCount = 8,               // 8 bits per channel
                    CompressionMethod = CompressionMethod.Raw // No compression (preserves data)
                };

                // Save as PSD preserving the alpha channel
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
 * 1. When a designer needs to import vector EPS artwork into Photoshop while keeping a transparent background for layer compositing, a developer can use this code to convert EPS to PSD with an alpha channel.
 * 2. When an automated publishing pipeline must generate PSD mock‑ups from EPS logos without losing transparency, the code enables C# batch conversion preserving RGBA data.
 * 3. When a web service receives EPS files from users and must store them as PSD files for further editing in Adobe Photoshop, this snippet ensures the alpha channel is retained during the conversion.
 * 4. When a digital asset management system migrates legacy EPS assets to PSD format for compatibility with modern tools, the code provides a reliable way to keep transparency intact.
 * 5. When a C# application needs to render EPS graphics on a transparent canvas and export the result as a PSD for layer‑based manipulation, this example shows how to configure PsdOptions to preserve the alpha channel.
 */