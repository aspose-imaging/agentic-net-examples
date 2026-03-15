using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths – adjust as needed
        string cmxPath = "canvas.cmx";
        string[] inputJpgPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        string outputPngPath = "merged.png";

        // Load CMX canvas to obtain target dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Prepare PNG options with a file create source
            Source pngSource = new FileCreateSource(outputPngPath, false);
            PngOptions pngOptions = new PngOptions { Source = pngSource };

            // Create a raster canvas bound to the PNG file
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0; // horizontal offset for stitching

                // Merge each JPG onto the canvas side‑by‑side
                foreach (string jpgPath in inputJpgPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jpgPath))
                    {
                        // Define where the current image will be placed
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);

                        // Copy pixel data from the source image to the canvas
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));

                        // Update offset for the next image
                        offsetX += img.Width;
                    }
                }

                // Save the final PNG (bound image)
                canvas.Save();
            }
        }
    }
}