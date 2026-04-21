using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DjVu file and output TIFF file
        string inputPath = "input.djvu";
        string outputTiffPath = "merged.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Temporary directory for intermediate PNG files
        string tempDir = "temp";
        Directory.CreateDirectory(tempDir); // unconditional creation

        // Convert pages 1‑3 of DjVu to PNG
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            int pagesToConvert = Math.Min(3, djvu.Pages.Length);
            for (int i = 0; i < pagesToConvert; i++)
            {
                string pngPath = Path.Combine(tempDir, $"page{i + 1}.png");
                // Ensure directory exists (already created above)
                djvu.Pages[i].Save(pngPath, new PngOptions());
            }
        }

        // Collect generated PNG paths
        List<string> pngPaths = new List<string>();
        for (int i = 1; i <= 3; i++)
        {
            string path = Path.Combine(tempDir, $"page{i}.png");
            if (File.Exists(path))
                pngPaths.Add(path);
        }

        if (pngPaths.Count == 0)
        {
            Console.Error.WriteLine("No PNG pages were generated.");
            return;
        }

        // Load first PNG to obtain dimensions
        using (RasterImage first = (RasterImage)Image.Load(pngPaths[0]))
        {
            int width = first.Width;
            int height = first.Height;

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            // Create a multipage TIFF canvas
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Save pixels of the first frame
                tiff.SavePixels(tiff.Bounds, first.LoadPixels(first.Bounds));

                // Process remaining PNGs
                for (int i = 1; i < pngPaths.Count; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(pngPaths[i]))
                    {
                        // Add a new frame to the TIFF
                        tiff.AddFrame(new TiffFrame(tiffOptions, img.Width, img.Height));
                        // Save pixels into the newly added frame
                        tiff.Frames[i].SavePixels(tiff.Frames[i].Bounds, img.LoadPixels(img.Bounds));
                    }
                }

                // Ensure output directory exists
                string outDir = Path.GetDirectoryName(outputTiffPath);
                if (!string.IsNullOrWhiteSpace(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Save the multipage TIFF
                tiff.Save(outputTiffPath);
            }
        }
    }
}