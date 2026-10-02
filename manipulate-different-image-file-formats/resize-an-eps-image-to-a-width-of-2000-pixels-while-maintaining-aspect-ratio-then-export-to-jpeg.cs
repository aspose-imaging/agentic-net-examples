// HOW-TO: Resize EPS to 2000px Width and Convert to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int originalWidth = epsImage.Width;
                int originalHeight = epsImage.Height;

                int targetWidth = 2000;
                int targetHeight = (int)Math.Round((double)originalHeight * targetWidth / originalWidth);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = targetWidth,
                    PageHeight = targetHeight
                };

                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When a designer provides vector EPS logos that need to be displayed on a website as optimized JPEG thumbnails of a fixed width.
 * 2. When an e‑commerce platform must generate product images from EPS artwork, scaling them to 2000 px wide while preserving proportions for high‑resolution displays.
 * 3. When a print‑to‑web workflow requires converting multi‑page EPS files to single‑page JPEGs with consistent width for email newsletters.
 * 4. When a batch‑processing script needs to downsize large EPS diagrams to a manageable size before uploading them to a content‑management system.
 * 5. When a mobile app backend must rasterize EPS illustrations to JPEG at a specific width to ensure fast loading on devices with limited bandwidth.
 */
