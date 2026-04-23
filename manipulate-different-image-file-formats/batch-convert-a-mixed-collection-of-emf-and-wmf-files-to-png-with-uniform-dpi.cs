using System;
using System.IO;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDir);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath);
                if (!extension.Equals(".emf", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".wmf", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(filePath))
                {
                    VectorRasterizationOptions vectorOptions;

                    if (image is EmfImage)
                    {
                        var emfOptions = new EmfRasterizationOptions
                        {
                            PageSize = image.Size,
                            BackgroundColor = Aspose.Imaging.Color.White
                        };
                        vectorOptions = emfOptions;
                    }
                    else if (image is WmfImage)
                    {
                        var wmfOptions = new WmfRasterizationOptions
                        {
                            PageSize = image.Size,
                            BackgroundColor = Aspose.Imaging.Color.White
                        };
                        vectorOptions = wmfOptions;
                    }
                    else
                    {
                        continue;
                    }

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions
                    };

                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}