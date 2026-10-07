// HOW-TO: Convert PSD to TIFF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a design workflow requires converting Photoshop PSD files to high‑resolution TIFFs for print‑ready output using C#.
 * 2. When an application needs to batch‑process layered PSD assets and store them as lossless TIFF images for archival purposes.
 * 3. When a web service must generate TIFF previews of PSD files for client download without losing layer information.
 * 4. When integrating Aspose.Imaging into a .NET solution to transform PSD graphics into TIFF format for compatibility with legacy imaging systems.
 * 5. When automating the conversion of PSD source files to TIFF to ensure consistent color profiles and resolution across different platforms.
 */
