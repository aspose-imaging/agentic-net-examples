using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files (modify paths as needed)
        string[] inputFiles = new[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Output combined JPEG path
        string combinedJpegPath = @"C:\Images\combined.jpg";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight) canvasHeight = sz.Height;
        }

        // Create JPEG canvas with desired size
        Source jpegSource = new FileCreateSource(combinedJpegPath, false);
        JpegOptions jpegOptions = new JpegOptions { Source = jpegSource, Quality = 90 };
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the combined JPEG (bound image)
            canvas.Save();
        }

        // Convert the combined JPEG to compressed WMZ format
        string wmzPath = combinedJpegPath + ".wmz";
        using (Image img = Image.Load(combinedJpegPath))
        {
            var vectorOptions = new WmfRasterizationOptions { PageSize = img.Size };
            var wmfOptions = new WmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = vectorOptions
            };
            img.Save(wmzPath, wmfOptions);
        }
    }
}