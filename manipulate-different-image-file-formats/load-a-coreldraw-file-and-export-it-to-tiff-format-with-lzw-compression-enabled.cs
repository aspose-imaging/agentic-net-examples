using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.tif";

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

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options with LZW compression
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                    Predictor = TiffPredictor.Horizontal
                };

                // Save as TIFF using the configured options
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
 * 1. When a graphics workflow requires converting vector‑based CorelDRAW (.cdr) designs into lossless, LZW‑compressed TIFF files for high‑quality print production using C# and Aspose.Imaging.
 * 2. When an archival system needs to store legacy CorelDRAW artwork as space‑efficient TIFF images with LZW compression to preserve color fidelity while reducing storage costs.
 * 3. When a document management application must automatically transform uploaded CorelDRAW files into TIFF format for compatibility with downstream PDF or OCR pipelines in a .NET environment.
 * 4. When a batch‑processing service has to generate web‑ready preview images from CorelDRAW source files by exporting them as TIFF with LZW compression to balance image quality and file size.
 * 5. When a CAD‑to‑GIS integration tool converts engineering drawings saved as CorelDRAW files into TIFF raster layers with LZW compression for seamless import into GIS software.
 */