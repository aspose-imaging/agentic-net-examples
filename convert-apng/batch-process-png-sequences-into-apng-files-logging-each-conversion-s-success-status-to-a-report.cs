using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            string reportPath = Path.Combine(outputDirectory, "report.txt");
            StringBuilder reportBuilder = new StringBuilder();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    reportBuilder.AppendLine($"{Path.GetFileName(inputPath)} -> N/A : File not found");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".apng.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                    {
                        ApngOptions createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = 100, // 100 ms per frame
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                        {
                            apngImage.RemoveAllFrames();
                            apngImage.AddFrame(sourceImage);
                            apngImage.Save();
                        }
                    }

                    reportBuilder.AppendLine($"{Path.GetFileName(inputPath)} -> {Path.GetFileName(outputPath)} : Success");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error processing {inputPath}: {ex.Message}");
                    reportBuilder.AppendLine($"{Path.GetFileName(inputPath)} -> {Path.GetFileName(outputPath)} : Failed ({ex.Message})");
                }
            }

            File.WriteAllText(reportPath, reportBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}