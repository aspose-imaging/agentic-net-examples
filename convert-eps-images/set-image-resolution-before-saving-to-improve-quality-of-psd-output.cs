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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Example: set compression method (optional)
                    CompressionMethod = CompressionMethod.RLE,
                    // Set desired resolution (e.g., 300 DPI)
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as PSD with the specified options
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
 * 1. When a print shop receives high‑resolution bitmap artwork and needs to convert it to a PSD file with 300 DPI for accurate color separation and scaling.
 * 2. When a digital asset management system imports user‑uploaded BMP images and must store them as PSDs with consistent resolution for downstream editing in Photoshop.
 * 3. When an e‑commerce platform generates product mockups from BMP templates and saves them as PSDs at 300 DPI to ensure crisp detail on large‑format marketing prints.
 * 4. When a scientific imaging application converts microscope BMP captures to PSD format while preserving the original DPI to maintain measurement fidelity.
 * 5. When a mobile app backend processes scanned documents, converting them from BMP to PSD and setting the resolution to 300 DPI so that designers can edit the files without loss of quality.
 */