using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input JPEG image file paths
            string[] inputFiles = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Output PNG file path
            string outputFile = "combined.png";

            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
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
            foreach (var sz in sizes)
            {
                canvasWidth += sz.Width;
                if (sz.Height > canvasHeight)
                    canvasHeight = sz.Height;
            }

            // Create file source for the output PNG
            Source src = new FileCreateSource(outputFile, false);
            // Configure PNG options with the source
            PngOptions pngOptions = new PngOptions() { Source = src };

            // Create a raster canvas with the calculated size
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                // Merge each JPEG onto the canvas
                foreach (string path in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        // Define the region on the canvas where the current image will be placed
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        // Copy pixel data from the source image to the canvas
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        // Update horizontal offset for the next image
                        offsetX += img.Width;
                    }
                }

                // Save the combined image (bound image, source already set)
                canvas.Save();
            }
        }
    }
}