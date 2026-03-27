using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "sample.djvu";
        string pngDir = "png_pages";
        string outputPath = "merged.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(pngDir);
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu and export pages 1‑3 to PNG
        using (FileStream djvuStream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(djvuStream))
        {
            for (int i = 0; i < 3 && i < djvuImage.Pages.Length; i++)
            {
                DjvuPage page = (DjvuPage)djvuImage.Pages[i];
                string pngPath = Path.Combine(pngDir, $"page{i + 1}.png");
                page.Save(pngPath, new PngOptions());
            }
        }

        // Load first PNG to obtain dimensions
        string firstPng = Path.Combine(pngDir, "page1.png");
        if (!File.Exists(firstPng))
        {
            Console.Error.WriteLine($"File not found: {firstPng}");
            return;
        }

        using (RasterImage firstImg = (RasterImage)Image.Load(firstPng))
        {
            int width = firstImg.Width;
            int height = firstImg.Height;

            // Prepare TIFF options with output source
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Create TIFF canvas bound to the output file
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Copy first page pixels
                int[] pixels = firstImg.LoadArgb32Pixels(firstImg.Bounds);
                tiffImage.SaveArgb32Pixels(firstImg.Bounds, pixels);

                // Process remaining PNG pages (pages 2 and 3)
                for (int i = 2; i <= 3; i++)
                {
                    string pngPath = Path.Combine(pngDir, $"page{i}.png");
                    if (!File.Exists(pngPath))
                    {
                        Console.Error.WriteLine($"File not found: {pngPath}");
                        continue;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(pngPath))
                    {
                        // Add a new frame to the TIFF
                        tiffImage.AddFrame(new TiffFrame(tiffOptions, width, height));
                        int frameIndex = tiffImage.Frames.Length - 1;

                        // Copy PNG pixels into the new frame
                        int[] framePixels = img.LoadArgb32Pixels(img.Bounds);
                        tiffImage.Frames[frameIndex].SaveArgb32Pixels(img.Bounds, framePixels);
                    }
                }

                // Save the multipage TIFF
                tiffImage.Save();
            }
        }
    }
}