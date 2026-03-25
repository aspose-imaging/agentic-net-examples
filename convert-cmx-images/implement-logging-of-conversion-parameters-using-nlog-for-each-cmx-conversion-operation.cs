using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            using (PngOptions pngOptions = new PngOptions())
            {
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmx.Width,
                    PageHeight = cmx.Height
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                cmx.Save(outputPath, pngOptions);
            }
        }
    }
}