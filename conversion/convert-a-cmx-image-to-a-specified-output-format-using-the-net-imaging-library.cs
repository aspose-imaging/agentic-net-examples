using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Expect input CMX path and output path as arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input.cmx> <output.[png|jpg|bmp|gif|tif|pdf|wmf|emf|svg|webp]>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        string ext = Path.GetExtension(outputPath).ToLowerInvariant();

        // Load the CMX image.
        using (Image image = Image.Load(inputPath))
        {
            // Prepare vector rasterization options common for raster outputs.
            VectorRasterizationOptions vectorOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });
            vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            vectorOptions.SmoothingMode = SmoothingMode.None;

            // Determine appropriate save options based on output extension.
            ImageOptionsBase saveOptions = null;

            if (ext == ".png")
            {
                var opt = new PngOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                var opt = new JpegOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".bmp")
            {
                var opt = new BmpOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".gif")
            {
                var opt = new GifOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".tif" || ext == ".tiff")
            {
                var opt = new TiffOptions(TiffExpectedFormat.Default);
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".pdf")
            {
                var opt = new PdfOptions();
                opt.PdfDocumentInfo = new PdfDocumentInfo();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".wmf")
            {
                var opt = new WmfOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".emf")
            {
                var opt = new EmfOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".svg")
            {
                var opt = new SvgOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else if (ext == ".webp")
            {
                var opt = new WebPOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }
            else
            {
                // Fallback to JPEG if format is unsupported.
                var opt = new JpegOptions();
                opt.VectorRasterizationOptions = vectorOptions;
                saveOptions = opt;
            }

            // Save the image using the selected options.
            using (saveOptions)
            {
                image.Save(outputPath, saveOptions);
            }
        }
    }
}