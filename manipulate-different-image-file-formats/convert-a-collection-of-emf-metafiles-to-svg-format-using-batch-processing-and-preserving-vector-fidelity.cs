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
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");

        foreach (string emfFilePath in emfFiles)
        {
            if (!File.Exists(emfFilePath))
            {
                Console.Error.WriteLine($"File not found: {emfFilePath}");
                return;
            }

            string outputFileName = Path.GetFileNameWithoutExtension(emfFilePath) + ".svg";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EmfImage emfImage = (EmfImage)Image.Load(emfFilePath))
            using (SvgOptions svgOptions = new SvgOptions())
            {
                svgOptions.TextAsShapes = true;

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions();
                rasterOptions.BackgroundColor = Color.WhiteSmoke;
                rasterOptions.PageSize = emfImage.Size;
                rasterOptions.RenderMode = EmfRenderMode.Auto;

                svgOptions.VectorRasterizationOptions = rasterOptions;

                emfImage.Save(outputPath, svgOptions);
            }
        }
    }
}