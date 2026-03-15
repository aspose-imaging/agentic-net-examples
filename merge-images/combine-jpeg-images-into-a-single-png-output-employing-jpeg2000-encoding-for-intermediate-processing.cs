using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image paths
        string[] inputPaths = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output PNG path
        string outputPath = "combined.png";

        // Lists to hold processed images and their sizes
        List<RasterImage> processedImages = new List<RasterImage>();
        List<Size> sizeList = new List<Size>();

        // Convert each JPEG to JPEG2000 in memory and collect sizes
        foreach (string path in inputPaths)
        {
            using (RasterImage jpegImage = (RasterImage)Image.Load(path))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save JPEG image as JPEG2000 into the memory stream
                    Jpeg2000Options jp2Options = new Jpeg2000Options();
                    jpegImage.Save(ms, jp2Options);
                    ms.Position = 0;

                    // Load the JPEG2000 image back as a raster image
                    RasterImage jp2Image = (RasterImage)Image.Load(ms);
                    processedImages.Add(jp2Image);
                    sizeList.Add(jp2Image.Size);
                }
            }
        }

        // Calculate canvas size for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Create PNG canvas bound to the output file
        Source outputSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions() { Source = outputSource };
        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (RasterImage img in processedImages)
            {
                Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                offsetX += img.Width;
            }

            // Save the bound canvas
            canvas.Save();
        }

        // Dispose intermediate images
        foreach (RasterImage img in processedImages)
        {
            img.Dispose();
        }
    }
}