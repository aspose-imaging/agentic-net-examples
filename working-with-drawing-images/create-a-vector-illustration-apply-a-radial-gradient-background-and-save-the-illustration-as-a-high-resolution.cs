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
        try
        {
            // Define output path (ensure it contains a directory)
            string outputPath = "output\\highres.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TIFF options for a high‑resolution image
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
                tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;

                // Define image size (e.g., 2000x2000 pixels)
                int width = 2000;
                int height = 2000;

                // Create the blank TIFF image
                using (Image image = Image.Create(tiffOptions, width, height))
                {
                    // Prepare graphics object
                    Graphics graphics = new Graphics(image);

                    // Define outer and inner colors for the radial gradient
                    Aspose.Imaging.Color outerColor = Aspose.Imaging.Color.Blue;
                    Aspose.Imaging.Color innerColor = Aspose.Imaging.Color.Yellow;

                    // Number of concentric circles to simulate the radial gradient
                    int steps = 100;
                    float maxRadius = Math.Min(width, height) / 2f;
                    float centerX = width / 2f;
                    float centerY = height / 2f;

                    for (int i = 0; i < steps; i++)
                    {
                        // Interpolation factor (0 = outer, 1 = inner)
                        float t = (float)i / (steps - 1);

                        // Linear interpolation of ARGB components
                        int a = (int)(outerColor.A + t * (innerColor.A - outerColor.A));
                        int r = (int)(outerColor.R + t * (innerColor.R - outerColor.R));
                        int g = (int)(outerColor.G + t * (innerColor.G - outerColor.G));
                        int b = (int)(outerColor.B + t * (innerColor.B - outerColor.B));

                        Aspose.Imaging.Color stepColor = Aspose.Imaging.Color.FromArgb(a, r, g, b);

                        // Calculate radius for this step
                        float radius = maxRadius * (1 - t);

                        // Define bounding rectangle for the filled ellipse
                        float left = centerX - radius;
                        float top = centerY - radius;
                        float diameter = radius * 2;

                        using (SolidBrush brush = new SolidBrush(stepColor))
                        {
                            graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle((int)left, (int)top, (int)diameter, (int)diameter));
                        }
                    }

                    // Save the image to the specified path using the same TIFF options
                    image.Save(outputPath, tiffOptions);
                }
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
 * 1. When a publishing system must generate a high‑resolution TIFF cover page with a radial gradient background for print‑on‑demand books.
 * 2. When a GIS application needs to export a vector map overlay as a 2000×2000 pixel TIFF image with LZW compression for archival storage.
 * 3. When an e‑commerce platform creates product catalog pages that require a scalable vector illustration with a blue‑to‑yellow radial gradient saved as a lossless TIFF for high‑quality PDFs.
 * 4. When a medical imaging workflow produces a diagnostic illustration with a smooth radial shading and stores it as a contiguous‑planar TIFF to maintain color fidelity.
 * 5. When a desktop publishing tool programmatically generates a poster background using Aspose.Imaging’s Graphics API and saves it as a little‑endian TIFF for downstream Photoshop editing.
 */