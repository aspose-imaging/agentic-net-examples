using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = cmx.Width,
                PageHeight = cmx.Height
            };

            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = rasterOptions
            };

            cmx.Save(outputPath, tiffOptions);
        }
    }
}