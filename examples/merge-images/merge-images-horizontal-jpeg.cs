using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input image file paths (replace with actual paths)
        string[] imagePaths = { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal layout
        int canvasWidth = 0;
        int canvasHeight = 0;
        canvasWidth = sizes.Sum(s => s.Width);
        canvasHeight = sizes.Max(s => s.Height);

        // Prepare output file and JPEG options
        string outputPath = "merged_output.jpg";
        Source outputSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outputSource,
            Quality = 90
        };

        // Create JPEG canvas bound to the output file
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Merge images horizontally onto the canvas
            int offsetX = 0;
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (output file is already specified in options)
            canvas.Save();
        }
    }
}