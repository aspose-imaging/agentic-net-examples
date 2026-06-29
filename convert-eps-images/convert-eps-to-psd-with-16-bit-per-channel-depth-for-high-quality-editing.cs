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
                // Configure PSD saving options for 16‑bit per channel depth
                var psdOptions = new PsdOptions
                {
                    ChannelBitsCount = 16,                     // 16 bits per channel
                    ChannelsCount = 4,                         // RGBA
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb,
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
                    Version = 6                                 // Default PSD version
                };

                // Save the image as PSD using the configured options
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
 * 1. When a graphic designer needs to convert vector EPS artwork to a 16‑bit per channel PSD file for high‑quality raster editing in Photoshop, a developer can use this C# code to automate the conversion.
 * 2. When a printing workflow requires preserving color depth while transforming EPS logos into PSD layers for further retouching, the code provides a reliable .NET solution.
 * 3. When a digital asset management system must batch‑process EPS files into PSD format with 16‑bit depth to maintain image fidelity before archiving, this snippet handles the conversion programmatically.
 * 4. When an e‑learning platform wants to render EPS illustrations as editable PSD files for instructors to customize, the code enables seamless conversion using Aspose.Imaging for .NET.
 * 5. When a web service offers on‑the‑fly conversion of uploaded EPS files to high‑resolution PSD files for designers to download, the example demonstrates the necessary C# implementation.
 */