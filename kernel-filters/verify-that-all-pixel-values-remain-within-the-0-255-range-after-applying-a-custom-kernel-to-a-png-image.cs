using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel access
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                // Store original pixel data
                Color[,] original = new Color[width, height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        original[x, y] = raster.GetPixel(x, y);
                    }
                }

                // Define a 3×3 sharpening kernel
                int[,] kernel = new int[,]
                {
                    {  0, -1,  0 },
                    { -1,  5, -1 },
                    {  0, -1,  0 }
                };
                int kSize = 3;
                int kOffset = kSize / 2;

                // Apply convolution, clamping results to 0‑255
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int r = 0, g = 0, b = 0, a = 0;

                        for (int ky = 0; ky < kSize; ky++)
                        {
                            for (int kx = 0; kx < kSize; kx++)
                            {
                                int ix = x + kx - kOffset;
                                int iy = y + ky - kOffset;

                                if (ix >= 0 && ix < width && iy >= 0 && iy < height)
                                {
                                    Color src = original[ix, iy];
                                    int k = kernel[ky, kx];
                                    r += src.R * k;
                                    g += src.G * k;
                                    b += src.B * k;
                                    a += src.A * k;
                                }
                            }
                        }

                        // Clamp each channel to the 0‑255 range
                        r = Math.Max(0, Math.Min(255, r));
                        g = Math.Max(0, Math.Min(255, g));
                        b = Math.Max(0, Math.Min(255, b));
                        a = Math.Max(0, Math.Min(255, a));

                        raster.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When a developer needs to apply a custom sharpening filter to PNG assets for a web application and must ensure the resulting pixel values stay within the 0‑255 range to avoid color distortion.
 * 2. When building an automated image‑processing pipeline that processes user‑uploaded PNG files with custom convolution kernels and requires validation that no pixel exceeds the byte range before saving.
 * 3. When creating a desktop photo‑editing tool in C# that lets users experiment with custom kernels on PNG images and needs to clamp pixel values to prevent overflow errors.
 * 4. When integrating Aspose.Imaging into a server‑side service that generates thumbnails from PNG sources using a custom kernel and must guarantee valid RGB/A values for downstream rendering.
 * 5. When performing quality‑control checks on batch‑processed PNG graphics where a custom convolution is applied and the code must verify that all pixel components remain between 0 and 255 to maintain compliance with PNG specifications.
 */