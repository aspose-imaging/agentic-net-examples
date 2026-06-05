using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
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
 * 1. When a user uploads a profile picture to Azure Blob storage, an Azure Function can automatically apply a Gaussian blur filter to obscure background details, ensuring consistent visual style and privacy compliance.
 * 2. When a marketing team stores high‑resolution product images in Blob storage, a serverless function can blur the edges to create soft‑focus thumbnails that load faster on e‑commerce sites.
 * 3. When scanned documents are saved as PNG files in Blob storage, an Azure Function can use Gaussian blur to reduce image noise before the files are processed by OCR engines for better text extraction accuracy.
 * 4. When a mobile app uploads user‑generated photos to Blob storage, a backend function can apply a Gaussian blur with a radius of 5 and sigma of 4.0 to generate stylized images for social media sharing without requiring client‑side processing.
 * 5. When a healthcare provider stores medical imaging data in Blob storage, an Azure Function can automatically blur patient identifiers in the images to meet HIPAA privacy requirements while preserving diagnostic details.
 */