// HOW-TO: Create High-Resolution TIFF with Vector Shapes and LZW Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.tif";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            int width = 2000;
            int height = 2000;

            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                Graphics graphics = new Graphics(tiffImage);

                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    graphics.FillRectangle(brush, new RectangleF(0, 0, width, height));
                }

                Pen pen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(pen, new RectangleF(200, 200, 1600, 1600));
                graphics.DrawEllipse(pen, new RectangleF(500, 500, 1000, 1000));

                tiffImage.Save(outputPath);
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
 * 1. When you need to generate a printable 2000 × 2000 pixel TIFF file containing vector shapes such as rectangles and ellipses for a catalog or brochure.
 * 2. When you want to programmatically create a high‑resolution raster image from vector drawing commands and save it with lossless LZW compression for archival purposes.
 * 3. When an application must produce a white‑background TIFF image with precise dimensions and embed simple graphics for use in GIS or medical imaging workflows.
 * 4. When you are building a C# service that automatically creates vector‑based diagrams and stores them as TIFF files compatible with legacy imaging systems.
 * 5. When you require a repeatable way to render basic vector illustrations into a TIFF format with specific TIFF options like little‑endian byte order and RGB photometric settings.
 */
