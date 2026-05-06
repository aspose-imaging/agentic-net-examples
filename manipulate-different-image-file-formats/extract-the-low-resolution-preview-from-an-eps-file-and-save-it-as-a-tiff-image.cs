using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/preview.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var preview = epsImage.GetPreviewImage(EpsPreviewFormat.TIFF);
                if (preview == null)
                {
                    Console.Error.WriteLine("No TIFF preview available in the EPS file.");
                    return;
                }

                using (preview)
                {
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    preview.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}