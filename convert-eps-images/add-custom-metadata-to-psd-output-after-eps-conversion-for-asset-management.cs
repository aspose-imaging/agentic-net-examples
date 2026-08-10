// HOW-TO: Convert EPS to PSD With RLE Compression And RGB Color Mode In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                epsImage.Save(outputPath, psdOptions);
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
 * 1. When a design workflow requires converting vector EPS artwork into layered PSD files for Photoshop editing while preserving RGB colors and reducing file size with RLE compression.
 * 2. When an automated asset pipeline needs to batch‑process EPS logos into PSDs for a web‑based brand‑asset manager that only supports Photoshop files.
 * 3. When a C# application must generate PSD previews of EPS illustrations for a digital asset management system that indexes images by format.
 * 4. When a publishing system converts EPS diagrams to PSD to apply Photoshop filters programmatically using Aspose.Imaging before final print production.
 * 5. When a graphics service needs to ensure consistent color mode (RGB) and lossless compression when transforming EPS files to PSD for downstream editing tools.
 */
