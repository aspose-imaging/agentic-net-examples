using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double[,] kernel = ConvolutionFilter.Emboss5x5;
                var filterOptions = new ConvolutionFilterOptions(kernel);

                raster.Filter(raster.Bounds, filterOptions);

                var source = new FileCreateSource(outputPath, false);
                var jpegOptions = new JpegOptions
                {
                    Source = source,
                    Quality = 90
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When a web service needs to generate stylized thumbnails of user‑uploaded photos hosted on a CDN, a developer can download the JPEG via HTTP, apply Aspose.Imaging’s Emboss5x5 convolution filter in C#, and save the result for display.
 * 2. When an e‑commerce platform wants to add a tactile “embossed” preview to product images fetched from external supplier URLs, the code can load the remote image, run the 5×5 emboss filter, and store the processed JPEG for the product gallery.
 * 3. When a social‑media analytics tool creates visual reports that highlight texture differences in images sourced from public APIs, a developer can pull each image over HTTP, apply the Emboss5x5 filter with Aspose.Imaging, and embed the output in PDF or HTML dashboards.
 * 4. When a digital signage system retrieves promotional banners from a remote server and needs to give them a raised‑edge effect without manual editing, the C# routine can fetch the image, apply the convolution emboss filter, and output a high‑quality JPEG for the display controller.
 * 5. When a mobile app backend processes user‑profile pictures stored on cloud storage to add a subtle embossed watermark before caching, the server‑side code can download the image via its URL, run the Emboss5x5 filter using Aspose.Imaging, and save the enhanced JPEG for fast delivery.
 */