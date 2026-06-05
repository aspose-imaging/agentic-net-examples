using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize EPS to a high‑resolution PNG in memory
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            using (var pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    // High resolution rasterization settings
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = 2000,   // desired width in pixels
                        PageHeight = 2000   // desired height in pixels
                    }
                };

                // Save EPS as PNG into the memory stream
                epsImage.Save(pngStream, pngOptions);
                pngStream.Position = 0; // reset stream for reading

                // Load the rasterized image
                using (var rasterImage = (RasterImage)Image.Load(pngStream))
                {
                    // Apply sharpening filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Prepare JPEG save options (high quality)
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };

                    // Save the sharpened image as JPEG
                    rasterImage.Save(outputPath, jpegOptions);
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
 * 1. When a print‑shop application must convert client‑provided EPS logos into crisp, high‑resolution JPEGs for on‑demand brochure printing, it can rasterize the vector file, sharpen the details, and save the result using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform needs to generate product thumbnail images from supplier EPS artwork, applying a sharpening filter ensures the JPEG previews look sharp on high‑DPI screens.
 * 3. When a digital asset management system imports legacy EPS files and creates searchable, high‑quality JPEG previews for quick browsing, the code rasterizes, sharpens, and exports the images at the required resolution.
 * 4. When a marketing automation tool prepares email campaign assets by converting EPS banners into optimized JPEGs, the sharpening step enhances edge clarity for better visual impact.
 * 5. When a scientific publishing workflow transforms EPS figures into high‑resolution JPEGs for online journals, applying a sharpening filter preserves fine details while meeting web‑friendly image standards.
 */