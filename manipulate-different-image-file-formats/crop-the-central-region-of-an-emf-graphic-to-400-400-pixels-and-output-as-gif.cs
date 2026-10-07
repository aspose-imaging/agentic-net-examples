// HOW-TO: Crop Center of EMF to 400x400 and Save as GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image emfImage = Image.Load(inputPath))
            {
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (emfImage.Width - cropWidth) / 2;
                int top = (emfImage.Height - cropHeight) / 2;
                if (left < 0) left = 0;
                if (top < 0) top = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                    vectorOptions.PageWidth = emfImage.Width;
                    vectorOptions.PageHeight = emfImage.Height;
                    vectorOptions.BackgroundColor = Color.White;

                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    emfImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                        GifOptions gifOptions = new GifOptions();
                        raster.Save(outputPath, gifOptions);
                    }
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
 * 1. When a developer needs to extract a 400 × 400 pixel thumbnail from the middle of a vector EMF logo and deliver it as a lightweight GIF for web previews.
 * 2. When an application must convert legacy EMF diagrams into animated‑compatible GIF frames while focusing on the central area for consistent layout.
 * 3. When a reporting tool has to generate fixed‑size GIF images from EMF charts to embed in PDF or email summaries without scaling distortion.
 * 4. When a batch‑processing service has to rasterize EMF files, crop the central region, and store the result as GIF for use in mobile apps with limited bandwidth.
 * 5. When a developer wants to programmatically create GIF icons from EMF assets, ensuring the icon shows the most important central details at exactly 400 × 400 pixels.
 */
