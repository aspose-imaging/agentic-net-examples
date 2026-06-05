using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\vector_illustration.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 2000;
            int height = 2000;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            using (Image image = Image.Create(tiffOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen redPen = new Pen(Color.Red, 5);
                graphics.DrawEllipse(redPen, new Rectangle(200, 200, 1600, 1200));

                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(blueBrush, new Rectangle(300, 300, 1400, 1400));

                Pen greenPen = new Pen(Color.Green, 3);
                graphics.DrawLine(greenPen, new Point(0, 0), new Point(width, height));

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
 * 1. When a developer needs to generate a printable high‑resolution vector diagram (e.g., a technical schematic) on the fly and store it as a lossless LZW‑compressed TIFF for archival or publishing.
 * 2. When an automated reporting system must create custom graphics such as ellipses, filled rectangles, and diagonal lines in C# and embed them into a multi‑page TIFF document for inclusion in engineering reports.
 * 3. When a web service creates dynamic map overlays or branding assets, draws vector shapes with specific pen widths and colors, and returns the result as a 2000×2000 TIFF that can be opened by any image viewer.
 * 4. When a batch‑processing tool needs to convert programmatically generated vector artwork into a TIFF file with RGB photometric settings and contiguous planar configuration for downstream GIS or printing pipelines.
 * 5. When a desktop application must programmatically generate a high‑quality rasterized illustration from vector primitives, apply a solid background, and save it with LZW compression to reduce file size without losing color fidelity.
 */