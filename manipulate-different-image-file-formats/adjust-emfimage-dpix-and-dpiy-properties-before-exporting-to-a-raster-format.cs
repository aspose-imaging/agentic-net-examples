using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.emf";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    var rasterOptions = new EmfRasterizationOptions();
                    rasterOptions.BackgroundColor = Color.White;
                    rasterOptions.PageSize = emfImage.Size;
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    emfImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}