using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputJpegs";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        VectorRasterizationOptions = vectorOptions
                    };

                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}