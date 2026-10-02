// HOW-TO: Apply Sharpen Kernel to Indexed PNG While Preserving Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.IColorPalette originalPalette = null;
                if (img is PngImage pngImg && pngImg.Palette != null)
                {
                    originalPalette = pngImg.Palette;
                }

                Aspose.Imaging.RasterImage raster = img as Aspose.Imaging.RasterImage;
                int width = raster.Width;
                int height = raster.Height;
                int[] pixels = raster.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height));

                double[,] kernel = new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                int kSize = 3;
                int kHalf = kSize / 2;
                int[] result = new int[pixels.Length];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        double a = 0, r = 0, g = 0, b = 0;
                        for (int ky = 0; ky < kSize; ky++)
                        {
                            int py = y + ky - kHalf;
                            if (py < 0 || py >= height) continue;
                            for (int kx = 0; kx < kSize; kx++)
                            {
                                int px = x + kx - kHalf;
                                if (px < 0 || px >= width) continue;
                                double coeff = kernel[ky, kx];
                                int srcPixel = pixels[py * width + px];
                                a += ((srcPixel >> 24) & 0xFF) * coeff;
                                r += ((srcPixel >> 16) & 0xFF) * coeff;
                                g += ((srcPixel >> 8) & 0xFF) * coeff;
                                b += (srcPixel & 0xFF) * coeff;
                            }
                        }
                        int ai = Math.Clamp((int)Math.Round(a), 0, 255);
                        int ri = Math.Clamp((int)Math.Round(r), 0, 255);
                        int gi = Math.Clamp((int)Math.Round(g), 0, 255);
                        int bi = Math.Clamp((int)Math.Round(b), 0, 255);
                        result[y * width + x] = (ai << 24) | (ri << 16) | (gi << 8) | bi;
                    }
                }

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                if (originalPalette != null)
                {
                    options.Palette = originalPalette;
                }

                using (Aspose.Imaging.Image outImg = Aspose.Imaging.Image.Create(options, width, height))
                {
                    Aspose.Imaging.RasterImage outRaster = (Aspose.Imaging.RasterImage)outImg;
                    outRaster.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), result);
                    outImg.Save();
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
 * 1. When you need to sharpen a low‑color PNG for a web UI without losing its original palette.
 * 2. When converting legacy indexed PNG assets for a game and must keep exact color indices after applying a filter.
 * 3. When performing batch image enhancement on PNG icons while ensuring the file size stays small by preserving the indexed palette.
 * 4. When integrating custom convolution kernels into an ASP.NET image‑processing pipeline that works with palette‑based PNGs.
 * 5. When debugging image‑processing code and want to verify that applying a kernel does not corrupt the color table of a PNG.
 */
