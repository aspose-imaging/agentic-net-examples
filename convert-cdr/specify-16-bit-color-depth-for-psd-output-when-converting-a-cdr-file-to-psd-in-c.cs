using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.psd";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR vector image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Configure PSD saving options with 16‑bit per channel
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.ChannelBitsCount = 16; // 16 bits per channel
                    psdOptions.ChannelsCount = 4;     // RGBA
                    psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb;
                    psdOptions.CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw;
                    psdOptions.Version = 6; // Default PSD version

                    // Set vector rasterization options for proper rendering
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    };

                    // Save the image as PSD with the specified options
                    cdr.Save(outputPath, psdOptions);
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
 * 1. When a graphic designer needs to preserve the full tonal range of a high‑resolution CorelDRAW (CDR) illustration for professional printing, they can convert the file to a 16‑bit per channel PSD using Aspose.Imaging for .NET.
 * 2. When a workflow automates batch conversion of CDR assets to Photoshop files while maintaining lossless color fidelity for archival purposes, the code sets the PSD ChannelBitsCount to 16.
 * 3. When a developer integrates a C# service that generates print‑ready PSD layers from vector CDR files for a publishing platform, specifying 16‑bit depth ensures accurate color reproduction in CMYK‑to‑RGB conversions.
 * 4. When an e‑commerce site needs to create high‑dynamic‑range product mockups from CorelDRAW source files, converting to 16‑bit PSD allows downstream Photoshop scripts to apply tone‑mapping without banding.
 * 5. When a digital asset management system imports vector illustrations and stores them as PSDs for later editing in Photoshop, using Aspose.Imaging’s VectorRasterizationOptions with 16‑bit color depth guarantees that gradients and shadows remain smooth.
 */