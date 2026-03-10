using System;
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
        // Input JPEG image file paths
        List<string> imagePaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Output JPEG file path
        string outputPath = "merged_output.jpg";

        // Create JPEG options with bound output source
        Source source = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = source,
            Quality = 100
        };

        // Create a JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            // Merge each image onto the canvas side by side
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no need to specify options again)
            canvas.Save();
        }
    }
}