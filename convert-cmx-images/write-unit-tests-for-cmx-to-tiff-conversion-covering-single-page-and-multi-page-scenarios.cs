using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Single‑page CMX to TIFF conversion
        string singleInputPath = @"C:\TestData\single.cmx";
        string singleOutputPath = @"C:\TestOutput\single.tif";

        if (!File.Exists(singleInputPath))
        {
            Console.Error.WriteLine($"File not found: {singleInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(singleOutputPath));

        using (Image cmxImage = Image.Load(singleInputPath))
        {
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                tiffOptions.VectorRasterizationOptions = vectorOptions;

                cmxImage.Save(singleOutputPath, tiffOptions);
            }
        }

        // Multi‑page CMX to TIFF conversion (export first two pages)
        string multiInputPath = @"C:\TestData\multi.cmx";
        string multiOutputPath = @"C:\TestOutput\multi.tif";

        if (!File.Exists(multiInputPath))
        {
            Console.Error.WriteLine($"File not found: {multiInputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(multiOutputPath));

        using (Image cmxMultiImage = Image.Load(multiInputPath))
        {
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                // Export only first two pages if the image has more than two pages
                if (cmxMultiImage is IMultipageImage multipage && multipage.PageCount > 2)
                {
                    tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, 2));
                }

                // Vector rasterization options for CMX (vector) image
                if (cmxMultiImage is VectorImage)
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = cmxMultiImage.Width,
                        PageHeight = cmxMultiImage.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    tiffOptions.VectorRasterizationOptions = vectorOptions;
                }

                cmxMultiImage.Save(multiOutputPath, tiffOptions);
            }
        }

        // Simple verification
        if (File.Exists(singleOutputPath))
        {
            Console.WriteLine("Single‑page conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Single‑page conversion failed.");
        }

        if (File.Exists(multiOutputPath))
        {
            Console.WriteLine("Multi‑page conversion succeeded.");
        }
        else
        {
            Console.Error.WriteLine("Multi‑page conversion failed.");
        }
    }
}