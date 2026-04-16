using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files
        string[] inputPaths = {
            @"C:\Images\sample1.bmp",
            @"C:\Images\sample2.bmp"
        };

        // Corresponding output PDF files
        string[] outputPaths = {
            @"C:\Images\sample1.pdf",
            @"C:\Images\sample2.pdf"
        };

        // Simple 5x5 color matrix (identity with a slight red boost)
        double[,] colorMatrix = new double[5, 5]
        {
            { 1.2, 0.0, 0.0, 0.0, 0.0 }, // Red channel
            { 0.0, 1.0, 0.0, 0.0, 0.0 }, // Green channel
            { 0.0, 0.0, 1.0, 0.0, 0.0 }, // Blue channel
            { 0.0, 0.0, 0.0, 1.0, 0.0 }, // Alpha channel
            { 0.0, 0.0, 0.0, 0.0, 1.0 }  // Offset
        };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data
                using (RasterImage raster = (RasterImage)image)
                {
                    int width = raster.Width;
                    int height = raster.Height;

                    // Apply color matrix to each pixel
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Aspose.Imaging.Color srcColor = raster.GetPixel(x, y);

                            // Normalize components to 0‑1 range
                            double r = srcColor.R / 255.0;
                            double g = srcColor.G / 255.0;
                            double b = srcColor.B / 255.0;
                            double a = srcColor.A / 255.0;
                            double[] src = { r, g, b, a, 1.0 };
                            double[] dst = new double[5];

                            // Matrix multiplication
                            for (int row = 0; row < 5; row++)
                            {
                                double sum = 0.0;
                                for (int col = 0; col < 5; col++)
                                {
                                    sum += colorMatrix[row, col] * src[col];
                                }
                                dst[row] = sum;
                            }

                            // Clamp and convert back to byte range
                            byte nr = (byte)Math.Min(255, Math.Max(0, (int)(dst[0] * 255)));
                            byte ng = (byte)Math.Min(255, Math.Max(0, (int)(dst[1] * 255)));
                            byte nb = (byte)Math.Min(255, Math.Max(0, (int)(dst[2] * 255)));
                            byte na = (byte)Math.Min(255, Math.Max(0, (int)(dst[3] * 255)));

                            Aspose.Imaging.Color newColor = Aspose.Imaging.Color.FromArgb(na, nr, ng, nb);
                            raster.SetPixel(x, y, newColor);
                        }
                    }
                }

                // Save transformed image as PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}