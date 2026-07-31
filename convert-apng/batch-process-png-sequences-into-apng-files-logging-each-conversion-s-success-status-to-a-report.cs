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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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
            using (var reportWriter = new StreamWriter(reportPath, false))
            {
                foreach (var inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".apng");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
                    {
                        ApngOptions createOptions = new ApngOptions
                        {
                            Source = new FileCreateSource(outputPath, false),
                            DefaultFrameTime = 100,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apng = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                        {
                            apng.RemoveAllFrames();
                            apng.AddFrame(sourceImage);
                            apng.Save();
                        }
                    }

                    reportWriter.WriteLine($"{fileNameWithoutExt}.png -> {fileNameWithoutExt}.apng");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a game developer needs to convert a series of sprite PNG frames into animated PNG (APNG) files for smoother in‑game animations while generating a text report of each conversion’s success.
 * 2. When an e‑learning platform automates the creation of animated illustrations from PNG slide decks, using C# and Aspose.Imaging to batch produce APNG assets and log the results for quality assurance.
 * 3. When a marketing team prepares lightweight web banners by turning multiple PNG images into APNG animations and records the conversion status in a report to verify all assets were generated correctly.
 * 4. When a scientific visualization tool processes time‑lapse PNG image sequences into APNG movies for publication, employing batch processing in .NET and capturing success/failure details in a log file.
 * 5. When a mobile app developer builds a build‑time pipeline that converts UI icon PNG sequences into APNG files for iOS, while writing a concise report to track which icons were successfully transformed.
 */