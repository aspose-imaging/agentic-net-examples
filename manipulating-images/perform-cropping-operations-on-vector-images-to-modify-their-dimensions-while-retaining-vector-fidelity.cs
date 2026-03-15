using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tga;

class VectorCropExample
{
    static void Main()
    {
        // Directory containing source vector images
        string dir = @"C:\temp\";

        // ---------- SVG ----------
        using (Image image = Image.Load(dir + "sample.svg"))
        {
            SvgImage svg = (SvgImage)image;
            // Define central cropping rectangle
            Rectangle rect = new Rectangle(svg.Width / 4, svg.Height / 4, svg.Width / 2, svg.Height / 2);
            svg.Crop(rect);
            // Save cropped result as PNG to retain rasterized view
            svg.Save(dir + "sample_svg_cropped.png", new PngOptions());
        }

        // ---------- EMF ----------
        using (Image image = Image.Load(dir + "sample.emf"))
        {
            EmfImage emf = (EmfImage)image;
            Rectangle rect = new Rectangle(emf.Width / 4, emf.Height / 4, emf.Width / 2, emf.Height / 2);
            emf.Crop(rect);
            emf.Save(dir + "sample_emf_cropped.png", new PngOptions());
        }

        // ---------- WMF ----------
        using (Image image = Image.Load(dir + "sample.wmf"))
        {
            WmfImage wmf = (WmfImage)image;
            Rectangle rect = new Rectangle(wmf.Width / 4, wmf.Height / 4, wmf.Width / 2, wmf.Height / 2);
            wmf.Crop(rect);
            wmf.Save(dir + "sample_wmf_cropped.png", new PngOptions());
        }

        // ---------- DJVU ----------
        using (Image image = Image.Load(dir + "sample.djvu"))
        {
            DjvuImage djvu = (DjvuImage)image;
            Rectangle rect = new Rectangle(djvu.Width / 4, djvu.Height / 4, djvu.Width / 2, djvu.Height / 2);
            djvu.Crop(rect);
            djvu.Save(dir + "sample_djvu_cropped.png", new PngOptions());
        }

        // ---------- DICOM ----------
        using (Image image = Image.Load(dir + "sample.dicom"))
        {
            DicomImage dicom = (DicomImage)image;
            Rectangle rect = new Rectangle(dicom.Width / 4, dicom.Height / 4, dicom.Width / 2, dicom.Height / 2);
            dicom.Crop(rect);
            dicom.Save(dir + "sample_dicom_cropped.png", new PngOptions());
        }

        // ---------- APNG ----------
        using (Image image = Image.Load(dir + "sample.apng"))
        {
            ApngImage apng = (ApngImage)image;
            Rectangle rect = new Rectangle(apng.Width / 4, apng.Height / 4, apng.Width / 2, apng.Height / 2);
            apng.Crop(rect);
            apng.Save(dir + "sample_apng_cropped.png", new PngOptions());
        }

        // ---------- WEBP ----------
        using (Image image = Image.Load(dir + "sample.webp"))
        {
            WebpImage webp = (WebpImage)image;
            Rectangle rect = new Rectangle(webp.Width / 4, webp.Height / 4, webp.Width / 2, webp.Height / 2);
            webp.Crop(rect);
            webp.Save(dir + "sample_webp_cropped.png", new PngOptions());
        }

        // ---------- TGA ----------
        using (Image image = Image.Load(dir + "sample.tga"))
        {
            TgaImage tga = (TgaImage)image;
            Rectangle rect = new Rectangle(tga.Width / 4, tga.Height / 4, tga.Width / 2, tga.Height / 2);
            tga.Crop(rect);
            tga.Save(dir + "sample_tga_cropped.png", new PngOptions());
        }
    }
}