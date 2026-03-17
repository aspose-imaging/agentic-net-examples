using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Load a PNG image, convert to grayscale, and save as JPEG
        using (RasterImage raster = (RasterImage)Image.Load("input.png"))
        {
            raster.Grayscale();
            raster.Save("output_grayscale.jpg", new JpegOptions());
        }

        // Create a new PNG canvas, draw a line, and save
        PngOptions canvasOptions = new PngOptions
        {
            Source = new FileCreateSource("canvas.png", false)
        };
        using (Image canvas = Image.Create(canvasOptions, 400, 300))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Blue, 3);
            graphics.DrawLine(pen, new Point(50, 50), new Point(350, 250));
            canvas.Save(); // Save to the bound source
        }

        // Create an animated APNG from a single raster image
        using (RasterImage source = (RasterImage)Image.Load("input.png"))
        {
            ApngOptions apngCreateOptions = new ApngOptions
            {
                Source = new FileCreateSource("animation.apng", false),
                DefaultFrameTime = 100, // 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apng = (ApngImage)Image.Create(apngCreateOptions, source.Width, source.Height))
            {
                apng.RemoveAllFrames(); // Remove the default single frame

                int totalFrames = 5;
                for (int i = 0; i < totalFrames; i++)
                {
                    apng.AddFrame(source);
                    ApngFrame frame = (ApngFrame)apng.Pages[apng.PageCount - 1];
                    frame.AdjustGamma(i); // Simple variation per frame
                }

                apng.Save(); // Save the APNG to the bound source
            }
        }

        // Load an image and export it to TIFF format
        using (Image img = Image.Load("input.png"))
        {
            TiffOptions tiffOpts = new TiffOptions(TiffExpectedFormat.Default);
            img.Save("output.tiff", tiffOpts);
        }
    }
}