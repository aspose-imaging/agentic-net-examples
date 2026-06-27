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
            string inputPath = @"c:\temp\sample.bmp";
            string outputPath = @"c:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD options with RLE compression
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE
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
 * 1. When a developer needs to convert high‑resolution BMP assets to Photoshop PSD files while keeping lossless quality and reducing file size for faster upload to a design collaboration platform.
 * 2. When an automated image‑processing pipeline must generate PSD previews from scanned documents and wants to use RLE compression to keep the files compatible with Photoshop without bloating storage.
 * 3. When a desktop application exports user‑edited graphics to PSD format for further editing in Adobe Photoshop and wants to ensure the exported layers are losslessly compressed to meet client storage quotas.
 * 4. When a batch conversion tool processes large numbers of bitmap images into PSDs for archival purposes and requires RLE compression to balance image fidelity with manageable archive size.
 * 5. When a web service creates PSD files on‑the‑fly from uploaded BMP images and needs to use RLE compression to deliver high‑quality files quickly to downstream Photoshop‑based workflows.
 */