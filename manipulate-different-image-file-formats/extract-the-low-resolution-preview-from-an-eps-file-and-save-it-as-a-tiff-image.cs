using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/preview.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            if (!epsImage.HasRasterPreview)
            {
                Console.Error.WriteLine("No raster preview available in the EPS file.");
                return;
            }

            var preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
            if (preview == null)
            {
                Console.Error.WriteLine("Failed to retrieve TIFF preview.");
                return;
            }

            using (preview)
            using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                preview.Save(outputPath, tiffOptions);
            }
        }
    }
}