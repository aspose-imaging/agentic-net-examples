// HOW-TO: Convert EMF to Black and White TIFF with CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for CCITT Group 4 (Fax4) compression, 1‑bit B/W
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 1 },
                    Compression = TiffCompressions.CcittFax4,
                    Photometric = TiffPhotometrics.MinIsBlack
                };

                // If the source is a vector image, provide rasterization options
                if (image is VectorImage)
                {
                    var rasterOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    };
                    tiffOptions.VectorRasterizationOptions = rasterOptions;
                }

                // Save as TIFF with the specified options
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
 * 1. When you need to archive vector drawings from Windows Metafiles as compact, 1‑bit black‑and‑white TIFF files for fax or document management systems.
 * 2. When a printing workflow requires converting EMF logos into CCITT Group 4 compressed TIFFs to meet printer or OCR input specifications.
 * 3. When you want to reduce storage size of high‑resolution EMF schematics by rasterizing them into monochrome TIFFs for long‑term backup.
 * 4. When integrating a .NET application with a legacy system that only accepts B/W TIFF images, you can transform incoming EMF files on the fly.
 * 5. When preparing EMF technical diagrams for electronic filing, you need to generate 1‑bit TIFFs with MinIsBlack photometric to ensure correct visual rendering.
 */
