using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG files to merge
        string[] inputJpegPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg"
            // Add more paths as needed
        };

        // Temporary BMP file that will hold the merged image
        string tempBmpPath = "merged.bmp";

        // Final output JPEG file
        string outputJpegPath = "merged.jpg";

        // Collect sizes of all input images
        List<Aspose.Imaging.Size> imageSizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputJpegPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                imageSizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = imageSizes.Sum(s => s.Width);
        int canvasHeight = imageSizes.Max(s => s.Height);

        // Create a BMP canvas bound to the temporary file
        Source bmpSource = new FileCreateSource(tempBmpPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = bmpSource };
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            // Merge each JPEG onto the BMP canvas
            int offsetX = 0;
            foreach (string path in inputJpegPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the BMP canvas (bound image)
            canvas.Save();
        }

        // Load the merged BMP and save it as JPEG
        using (RasterImage mergedBmp = (RasterImage)Image.Load(tempBmpPath))
        {
            JpegOptions jpegOptions = new JpegOptions() { Quality = 100 };
            mergedBmp.Save(outputJpegPath, jpegOptions);
        }

        // Optional cleanup of the temporary BMP file
        if (File.Exists(tempBmpPath))
        {
            File.Delete(tempBmpPath);
        }
    }
}