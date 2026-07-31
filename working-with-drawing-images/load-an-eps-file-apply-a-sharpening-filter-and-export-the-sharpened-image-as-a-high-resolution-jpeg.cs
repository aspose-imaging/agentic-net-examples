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
                int rasterWidth = epsImage.Width * 2;
                int rasterHeight = epsImage.Height * 2;

                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = rasterWidth,
                    PageHeight = rasterHeight
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
 * 1. When a developer needs to convert a vector EPS logo into a high‑resolution JPEG for use on a product catalog website.
 * 2. When an e‑commerce platform must generate printable JPEG thumbnails from designer‑provided EPS artwork at double the original size.
 * 3. When a marketing automation tool has to batch‑process EPS brochures and output sharp, high‑dpi JPEG images for email campaigns.
 * 4. When a desktop publishing application requires on‑the‑fly rasterization of EPS files to JPEG so they can be displayed in a preview pane without vector support.
 * 5. When a legacy system stores assets as EPS and a migration script must transform them into JPEGs with increased pixel dimensions for a modern CMS.
 */