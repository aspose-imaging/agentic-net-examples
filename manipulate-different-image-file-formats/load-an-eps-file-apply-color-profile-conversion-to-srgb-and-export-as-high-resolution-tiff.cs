using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Convert color profile to sRGB if supported
                // epsImage.ConvertColorProfile(ColorProfile.Srgb);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                tiffOptions.VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                epsImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}