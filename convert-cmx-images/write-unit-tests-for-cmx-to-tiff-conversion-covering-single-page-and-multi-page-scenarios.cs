using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Single‑page CMX to TIFF conversion
        string inputSingle = "Input\\single.cmx";
        string outputSingle = "Output\\single.tif";

        if (!File.Exists(inputSingle))
        {
            Console.Error.WriteLine($"File not found: {inputSingle}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputSingle));

        using (Image image = Image.Load(inputSingle))
        {
            // Prepare TIFF options with vector rasterization settings
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            image.Save(outputSingle, tiffOptions);
        }

        // Multi‑page CMX to TIFF conversion
        string inputMulti = "Input\\multi.cmx";
        string outputMulti = "Output\\multi.tif";

        if (!File.Exists(inputMulti))
        {
            Console.Error.WriteLine($"File not found: {inputMulti}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputMulti));

        using (Image image = Image.Load(inputMulti))
        {
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Export all pages if the source is multipage
            if (image is IMultipageImage multipage && multipage.PageCount > 0)
            {
                tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, multipage.PageCount));
            }

            // Vector rasterization settings for CMX pages
            tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            image.Save(outputMulti, tiffOptions);
        }
    }
}