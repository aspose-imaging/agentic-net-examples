using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPG files to combine
        string[] inputFiles = new[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Output JPEG file
        string outputJpegPath = "combined.jpg";

        // Temporary WMF file used as intermediate canvas
        string tempWmfPath = "temp.wmf";

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputFiles)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions (horizontal stitching)
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Create WMF canvas
        Source wmfSource = new FileCreateSource(tempWmfPath, false);
        WmfOptions wmfOptions = new WmfOptions { Source = wmfSource };
        using (WmfImage wmfCanvas = (WmfImage)Image.Create(wmfOptions, canvasWidth, canvasHeight))
        {
            // Set background color
            wmfCanvas.BackgroundColor = Aspose.Imaging.Color.White;

            // Graphics object for drawing
            Graphics graphics = new Graphics(wmfCanvas);

            int offsetX = 0;
            foreach (string path in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Draw each JPG onto the WMF canvas
                    graphics.DrawImage(img, new Point(offsetX, 0));
                    offsetX += img.Width;
                }
            }

            // Save the WMF file
            wmfCanvas.Save();
        }

        // Convert the intermediate WMF to final JPEG
        Source jpegSource = new FileCreateSource(outputJpegPath, false);
        JpegOptions jpegOptions = new JpegOptions { Source = jpegSource, Quality = 90 };
        using (WmfImage wmf = (WmfImage)Image.Load(tempWmfPath))
        {
            wmf.Save(outputJpegPath, jpegOptions);
        }

        // Optional: clean up temporary WMF file
        // System.IO.File.Delete(tempWmfPath);
    }
}