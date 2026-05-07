using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
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
            string[] imageUrls = {
                "https://example.com/image1.jpg",
                "https://example.com/image2.jpg"
            };
            string outputPath = "merged.jpg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare HTTP client
            HttpClient httpClient = new HttpClient();

            // First pass: collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string url in imageUrls)
            {
                using (Stream stream = httpClient.GetStreamAsync(url).Result)
                using (RasterImage img = (RasterImage)Image.Load(stream))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (Size sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create JPEG options with bound source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 90
            };

            // Create canvas and merge images vertically
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string url in imageUrls)
                {
                    using (Stream stream = httpClient.GetStreamAsync(url).Result)
                    using (RasterImage img = (RasterImage)Image.Load(stream))
                    {
                        Rectangle bounds = new Rectangle(0, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}