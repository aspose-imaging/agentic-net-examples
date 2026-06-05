using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int width = epsImage.Width;
                int height = epsImage.Height;

                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height
                    }
                };

                using (var ms = new MemoryStream())
                {
                    epsImage.Save(ms, jpegOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            int argb = pixels[i];
                            int a = argb & unchecked((int)0xFF000000);
                            int rgb = argb & 0x00FFFFFF;
                            int invRgb = (~rgb) & 0x00FFFFFF;
                            pixels[i] = a | invRgb;
                        }
                        raster.SaveArgb32Pixels(raster.Bounds, pixels);
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When a printing workflow needs to generate preview thumbnails of EPS artwork with inverted colors for a dark‑mode UI, a developer can load the EPS, rasterize it, invert the ARGB pixels, and save a 100‑quality JPEG.
 * 2. When an e‑commerce platform wants to display product mockups with a negative‑film effect, the code can read the EPS vector logo, apply a color inversion filter, and export a high‑resolution JPEG for web use.
 * 3. When a digital asset management system must create watermarked, color‑inverted JPEG copies of EPS logos for archival compliance, this snippet shows how to rasterize, invert, and save the image at maximum quality.
 * 4. When a mobile app needs to generate night‑mode icons from vector EPS resources, developers can use Aspose.Imaging to load the EPS, invert its colors, and output a crisp JPEG suitable for low‑light displays.
 * 5. When an automated testing suite validates visual contrast by comparing original EPS files to their inverted JPEG versions, the code demonstrates loading, pixel‑level inversion, and high‑quality JPEG export in C#.
 */