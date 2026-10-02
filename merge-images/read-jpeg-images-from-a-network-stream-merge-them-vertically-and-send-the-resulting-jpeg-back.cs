// HOW-TO: Merge Multiple JPEG Images From URLs Into a Single Vertical JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input URLs and output path
            string[] imageUrls = new string[]
            {
                "http://example.com/image1.jpg",
                "http://example.com/image2.jpg",
                "http://example.com/image3.jpg"
            };
            string outputPath = "output/merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold loaded images
            List<RasterImage> loadedImages = new List<RasterImage>();

            // Load images from network streams
            using (HttpClient client = new HttpClient())
            {
                foreach (string url in imageUrls)
                {
                    using (Stream stream = client.GetStreamAsync(url).Result)
                    {
                        RasterImage img = (RasterImage)Image.Load(stream);
                        loadedImages.Add(img);
                    }
                }
            }

            if (loadedImages.Count == 0)
            {
                Console.Error.WriteLine("No images were loaded.");
                return;
            }

            // Calculate canvas size for vertical merge
            int canvasWidth = loadedImages.Max(img => img.Width);
            int canvasHeight = loadedImages.Sum(img => img.Height);

            // Create JPEG canvas bound to output file
            Source source = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (RasterImage img in loadedImages)
                {
                    Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetY += img.Height;
                }

                // Save the bound image
                canvas.Save();
            }

            // Dispose loaded images
            foreach (RasterImage img in loadedImages)
            {
                img.Dispose();
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
 * 1. When a web service needs to combine user‑uploaded photos hosted on different URLs into one tall image for a printable collage.
 * 2. When an e‑commerce platform wants to create a single product‑detail image by stacking several JPEG screenshots of a product from a CDN.
 * 3. When a reporting tool must fetch chart images from a remote server and merge them vertically before embedding the result in a PDF.
 * 4. When a mobile app backend assembles a continuous scrolling banner by concatenating remote JPEG banners into one image.
 * 5. When an automated email generator pulls promotional JPEGs from marketing URLs and merges them into a single image to reduce attachment size.
 */
