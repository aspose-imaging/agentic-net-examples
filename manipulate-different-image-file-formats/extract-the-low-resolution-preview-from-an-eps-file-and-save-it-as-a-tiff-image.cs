using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

        using (Image epsImage = Image.Load(inputPath))
        {
            dynamic eps = epsImage;
            using (Image preview = eps.GetPreviewImage())
            {
                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                preview.Save(outputPath);
            }
        }
    }
}