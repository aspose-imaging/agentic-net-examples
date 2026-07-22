using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputWebP = @"C:\temp\input.webp";
            string bmpPath = @"C:\temp\intermediate.bmp";
            string tiffPath = @"C:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputWebP))
            {
                Console.Error.WriteLine($"File not found: {inputWebP}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tiffPath));

            // Load WebP and save as BMP
            using (WebPImage webPImage = new WebPImage(inputWebP))
            {
                webPImage.Save(bmpPath, new BmpOptions());
            }

            // Load BMP and save as TIFF with LZW compression
            using (Image bmpImage = Image.Load(bmpPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.LittleEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                bmpImage.Save(tiffPath, tiffOptions);
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
 * 1. When a developer needs to archive web‑optimized WebP graphics in a lossless, LZW‑compressed TIFF format for long‑term storage or compliance, they can use this Aspose.Imaging C# code to convert WebP to BMP and then to TIFF.
 * 2. When an application must generate high‑quality printable files from WebP assets, the code converts the WebP image to a BMP intermediate and then saves it as a TIFF with LZW compression to meet print‑industry standards.
 * 3. When a .NET service processes user‑uploaded WebP photos and needs to store them in a TIFF container for compatibility with legacy GIS or medical imaging systems, this snippet performs the required format conversion using Aspose.Imaging.
 * 4. When a batch‑processing tool has to convert a folder of WebP images into TIFF files with reduced file size but without losing color fidelity, the example shows how to use C# and Aspose.Imaging to achieve LZW‑compressed TIFF output.
 * 5. When a developer is building a digital asset management system that must preserve original image quality while supporting both web (WebP) and archival (TIFF) formats, this code demonstrates the step‑by‑step conversion using BMP as an intermediate format.
 */