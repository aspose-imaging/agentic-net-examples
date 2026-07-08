using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string tempPngPath = @"C:\Images\temp.png";
            string outputPath = @"C:\Images\sample_converted.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImg = Image.Load(inputPath))
            {
                // Cast to OdgImage to access vector rasterization options
                OdgImage odgImage = (OdgImage)odgImg;

                // Prepare PNG options with rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(new MemoryStream(), false),
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    }
                };

                // Save ODG as a temporary PNG (raster image)
                odgImage.Save(tempPngPath, pngOptions);
            }

            // Load the temporary PNG as a raster image
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)rasterImg;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as JPEG
                JpegOptions jpegOptions = new JpegOptions(); // default options
                rasterImage.Save(outputPath, jpegOptions);
            }

            // Optionally delete the temporary PNG file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { /* ignore cleanup errors */ }
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
 * 1. When a developer needs to clean up scanned hand‑drawn diagrams stored as ODG files by removing salt‑and‑pepper noise before publishing them as JPEGs on a web portal.
 * 2. When an application must batch‑process OpenDocument graphics from a CAD system, apply a median filter to smooth edges, and convert the results to JPEG for inclusion in email reports.
 * 3. When a document management workflow requires converting vector ODG illustrations to raster JPEG thumbnails while preserving visual quality by denoising with a median filter in C#.
 * 4. When a mobile‑first website needs lightweight JPEG previews of ODG charts, and the server‑side code uses Aspose.Imaging to rasterize, median‑filter, and compress the images.
 * 5. When a legacy archival tool must transform ODG artwork into JPEG format for archival storage, applying a median filter to mitigate compression artifacts introduced during the conversion.
 */