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
            string outputPath = "output.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 4000;
            int height = 3000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to generate a high‑resolution (4000×3000) TIFF file for archival printing, they can use Aspose.Imaging in C# to create the image with LZW compression and RGB photometric settings.
 * 2. When an application must export large raster graphics for GIS or satellite‑imagery workflows, this code shows how to programmatically produce a contiguous planar TIFF with specified bits‑per‑sample.
 * 3. When a document‑management system requires lossless storage of scanned documents, developers can employ the snippet to create a compressed TIFF that balances file size and image quality.
 * 4. When a medical‑imaging solution needs to output diagnostic images in a standard format, the example demonstrates creating a 24‑bit RGB TIFF using Aspose.Imaging’s TiffOptions in .NET.
 * 5. When a batch‑processing tool must generate placeholder images for testing image‑processing pipelines, the code provides a quick way to programmatically create high‑resolution TIFF files with configurable compression.
 */