using System;
using System.IO;
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
            string reportPath = Path.Combine(outputDirectory, "report.txt");

            // Ensure output directory exists for report and later saves
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            using (StreamWriter reportWriter = new StreamWriter(reportPath, append: true))
            {
                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".apng";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
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

                            using (ApngImage apngImage = (ApngImage)Image.Create(
                                createOptions,
                                sourceImage.Width,
                                sourceImage.Height))
                            {
                                apngImage.RemoveAllFrames();
                                apngImage.AddFrame(sourceImage);
                                apngImage.Save();
                            }
                        }

                        reportWriter.WriteLine($"{DateTime.Now}: SUCCESS - Converted '{inputPath}' to '{outputPath}'.");
                        Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                    }
                    catch (Exception ex)
                    {
                        reportWriter.WriteLine($"{DateTime.Now}: FAILURE - '{inputPath}' -> '{outputPath}'. Error: {ex.Message}");
                        Console.Error.WriteLine($"Error processing '{inputPath}': {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}