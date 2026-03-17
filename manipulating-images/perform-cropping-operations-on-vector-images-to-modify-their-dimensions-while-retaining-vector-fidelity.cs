using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class VectorCropDemo
{
    static void Main()
    {
        string dir = @"C:\temp\";

        // Crop an SVG image and save it back as SVG
        using (Image img = Image.Load(dir + "sample.svg"))
        {
            SvgImage svg = (SvgImage)img;
            // Define a central rectangle (half the width and height)
            var rect = new Rectangle(svg.Width / 4, svg.Height / 4, svg.Width / 2, svg.Height / 2);
            svg.Crop(rect);
            // Save the cropped SVG preserving vector data
            svg.Save(dir + "sample_cropped.svg", new SvgOptions());
        }

        // Crop an EMF image and save it back as EMF
        using (Image img = Image.Load(dir + "sample.emf"))
        {
            EmfImage emf = (EmfImage)img;
            var rect = new Rectangle(emf.Width / 4, emf.Height / 4, emf.Width / 2, emf.Height / 2);
            emf.Crop(rect);
            emf.Save(dir + "sample_cropped.emf", new EmfOptions());
        }

        // Crop a WMF image and save it back as WMF
        using (Image img = Image.Load(dir + "sample.wmf"))
        {
            WmfImage wmf = (WmfImage)img;
            var rect = new Rectangle(wmf.Width / 4, wmf.Height / 4, wmf.Width / 2, wmf.Height / 2);
            wmf.Crop(rect);
            wmf.Save(dir + "sample_cropped.wmf", new WmfOptions());
        }

        // Crop a DJVU image (vector‑like) and save the result as PNG
        using (Image img = Image.Load(dir + "sample.djvu"))
        {
            DjvuImage djvu = (DjvuImage)img;
            var rect = new Rectangle(djvu.Width / 4, djvu.Height / 4, djvu.Width / 2, djvu.Height / 2);
            djvu.Crop(rect);
            // Saving as PNG after cropping; the vector content is rasterized at save time
            djvu.Save(dir + "sample_cropped.png", new PngOptions());
        }
    }
}