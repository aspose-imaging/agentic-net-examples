using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG image paths (modify as needed)
        List<string> imagePaths = new List<string>
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Collect widths and heights of all images
        List<int> widths = new List<int>();
        List<int> heights = new List<int>();

        foreach (string path in imagePaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                widths.Add(img.Width);
                heights.Add(img.Height);
            }
        }

        // Calculate canvas size for horizontal stitching
        int canvasWidth = widths.Sum();
        int canvasHeight = heights.Max();

        // Prepare output file and options for JPEG2000
        string outputPath = "combined_output.j2k";
        Source outputSource = new FileCreateSource(outputPath, false);
        Jpeg2000Options jp2Options = new Jpeg2000Options
        {
            Source = outputSource,
            Irreversible = true,          // use lossless wavelet transform
            KeepMetadata = true           // preserve metadata from source images
        };

        // Create a blank canvas bound to the output source
        using (RasterImage canvas = (RasterImage)Image.Create(jp2Options, canvasWidth, canvasHeight))
        {
            int offsetX = 0;

            // Merge each JPEG onto the canvas
            foreach (string path in imagePaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    // Define destination rectangle on the canvas
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);

                    // Copy pixel data
                    canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));

                    // Update horizontal offset
                    offsetX += img.Width;
                }
            }

            // Save the bound canvas (no need to specify path again)
            canvas.Save();
        }
    }
}