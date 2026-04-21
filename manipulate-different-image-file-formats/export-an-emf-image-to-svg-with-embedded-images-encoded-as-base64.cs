using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\temp\\input.emf";
        string outputPath = "C:\\temp\\output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                emfImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}