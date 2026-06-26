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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.eps";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
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
                // Configure PSD options with balanced compression (RLE)
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE, // RLE offers good compression while preserving quality
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    ChannelBitsCount = 8,
                    ChannelsCount = 4,
                    Version = 6
                };

                // Save the image as PSD using the specified options
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
 * 1. When a graphic design studio needs to convert client‑provided EPS logos to layered PSD files while keeping the file size small enough for web upload, they can use this code to apply RLE compression.
 * 2. When an automated build pipeline processes print‑ready EPS artwork and must generate PSD previews for a content management system without sacrificing color fidelity, the code balances quality with storage efficiency.
 * 3. When a SaaS platform offers on‑the‑fly EPS to PSD conversion for users with limited bandwidth, developers can employ this snippet to set the PSD compression method to RLE for faster downloads.
 * 4. When a digital asset management system archives thousands of EPS files as PSDs and needs to reduce disk usage while preserving the original RGB channels, the code provides a practical solution.
 * 5. When a C# desktop application allows designers to edit EPS files in Photoshop by first saving them as PSDs with controlled compression, this example ensures the PSDs remain high‑quality yet manageable in size.
 */