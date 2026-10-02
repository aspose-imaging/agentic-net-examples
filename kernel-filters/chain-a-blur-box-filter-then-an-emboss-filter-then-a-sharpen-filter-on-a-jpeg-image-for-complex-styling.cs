// HOW-TO: Apply Blur, Emboss, and Sharpen Filters to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] blurKernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };
                image.Filter(image.Bounds, new ConvolutionFilterOptions(blurKernel));

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };
                image.Filter(image.Bounds, new ConvolutionFilterOptions(embossKernel));

                image.Filter(image.Bounds, new SharpenFilterOptions());

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften an image, add a textured emboss effect, and then enhance edges before saving as a high‑quality JPEG for web galleries.
 * 2. When preparing product photos for an e‑commerce site and want a subtle blur to reduce noise, an emboss to highlight details, and sharpening to make the final image crisp.
 * 3. When creating stylized thumbnails for a mobile app where a combination of blur, emboss, and sharpen gives a distinctive visual signature.
 * 4. When processing scanned documents to smooth background, emphasize text edges with emboss, and sharpen for better OCR accuracy before exporting to JPEG.
 * 5. When building an automated image pipeline that applies multiple convolution filters sequentially to achieve a custom artistic look on JPEG assets.
 */
