using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JPEG files
            string[] inputPaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Hardcoded output PNG file
            string outputPath = "output/merged.png";

            // Validate input files
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Lists to hold pixel data and sizes
            List<int[]> pixelDataList = new List<int[]>();
            List<Size> sizeList = new List<Size>();

            // Load each JPEG, flip horizontally, and store pixel data
            foreach (string path in inputPaths)
            {
                using (Image img = Image.Load(path))
                {
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    RasterImage raster = (RasterImage)img;
                    int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                    pixelDataList.Add(pixels);
                    sizeList.Add(raster.Size);
                }
            }

            // Calculate canvas dimensions for horizontal layout
            int totalWidth = 0;
            int maxHeight = 0;
            foreach (Size sz in sizeList)
            {
                totalWidth += sz.Width;
                if (sz.Height > maxHeight) maxHeight = sz.Height;
            }

            // Create PNG canvas with bound source
            Source src = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = src };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                for (int i = 0; i < pixelDataList.Count; i++)
                {
                    Size sz = sizeList[i];
                    Rectangle bounds = new Rectangle(offsetX, 0, sz.Width, sz.Height);
                    canvas.SaveArgb32Pixels(bounds, pixelDataList[i]);
                    offsetX += sz.Width;
                }

                // Save the composed image
                canvas.Save();
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
 * 1. When creating a product catalog that shows mirrored side‑view photos of items, a developer can flip each JPEG horizontally, stitch them side‑by‑side, and output a single PNG for web display.
 * 2. When generating a before‑and‑after comparison for a photo‑editing app, the code can flip the original JPEGs, align them in a horizontal strip, and save the composite as a PNG thumbnail.
 * 3. When preparing a printable banner that requires mirrored images for a symmetrical design, the developer can use this routine to horizontally flip the source JPEGs, concatenate them, and export a high‑quality PNG.
 * 4. When building an e‑learning slide that demonstrates image reflection, the code can automatically mirror each JPEG, arrange them in a row, and produce a PNG for inclusion in PowerPoint.
 * 5. When automating the creation of a social‑media collage where each photo must appear as its mirror image, the solution flips the JPEGs, merges them horizontally, and saves the result as a PNG ready for upload.
 */