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
            const string inputDirectory = "Input";
            const string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory);

            const int targetWidth = 800;
            const int targetHeight = 600;

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);
                    using (JpegOptions options = new JpegOptions())
                    {
                        options.Quality = 90;
                        raster.Save(outputPath, options);
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
 * 1. When a web application needs to export a collection of HTML5 Canvas drawings that are stored as in‑memory image files into standardized 800 × 600 JPEG files for archival or reporting purposes.
 * 2. When an e‑learning platform generates student sketches on a canvas and must batch‑process them into JPEG thumbnails of uniform size before uploading to a content‑delivery network.
 * 3. When a digital signage system receives canvas snapshots from multiple kiosks and requires a C# routine to resize and convert them to high‑quality JPEGs for consistent display on screens.
 * 4. When a marketing automation tool collects canvas‑based banner drafts and needs to convert the batch to JPEG format with a fixed resolution for email campaign assets.
 * 5. When a document management workflow extracts canvas images from HTML reports and must batch‑convert them to JPEG with a set width and height to ensure they fit into PDF templates.
 */