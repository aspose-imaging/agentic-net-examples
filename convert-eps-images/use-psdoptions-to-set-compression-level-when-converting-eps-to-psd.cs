using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;

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
                // Configure PSD options with desired compression
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE // Use RLE compression; change to CompressionMethod.Raw for no compression
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
 * 1. When a graphic designer needs to batch‑convert EPS artwork to Photoshop PSD files while reducing file size with RLE compression for faster uploads to a cloud‑based review system.
 * 2. When an automated publishing pipeline must transform vector EPS logos into layered PSDs with controlled compression to meet the size limits of a digital asset management (DAM) repository.
 * 3. When a C# application integrates with a print‑preflight workflow and requires converting EPS proofs to PSDs using the CompressionMethod.RLE option to preserve image quality while minimizing storage costs.
 * 4. When a web service generates PSD mockups from EPS templates on‑the‑fly and needs to specify CompressionMethod.Raw or RLE via PsdOptions to balance between no compression for editing and compressed output for client download.
 * 5. When a legacy Photoshop plugin expects PSD input and a developer must programmatically load EPS files and save them as compressed PSDs in .NET to ensure compatibility with older Photoshop versions.
 */