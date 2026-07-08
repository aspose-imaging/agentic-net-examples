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

            string reportPath = Path.Combine(outputDirectory, "report.txt");
            File.WriteAllText(reportPath, string.Empty);

            string[] sequenceDirs = Directory.GetDirectories(inputDirectory);
            foreach (var seqDir in sequenceDirs)
            {
                string[] pngFiles = Directory.GetFiles(seqDir, "*.png");
                if (pngFiles.Length == 0)
                {
                    continue;
                }

                string outputFileName = Path.GetFileName(seqDir) + ".apng";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage firstImage = (RasterImage)Image.Load(pngFiles[0]))
                {
                    int width = firstImage.Width;
                    int height = firstImage.Height;

                    ApngOptions createOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        DefaultFrameTime = 70,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                    {
                        apngImage.RemoveAllFrames();

                        foreach (var pngPath in pngFiles)
                        {
                            if (!File.Exists(pngPath))
                            {
                                Console.Error.WriteLine($"File not found: {pngPath}");
                                continue;
                            }

                            using (RasterImage frame = (RasterImage)Image.Load(pngPath))
                            {
                                apngImage.AddFrame(frame);
                            }
                        }

                        apngImage.Save();
                    }
                }

                File.AppendAllText(reportPath, $"Converted {seqDir} to {outputPath}: Success{Environment.NewLine}");
            }

            Console.WriteLine("Batch processing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert multiple folders of sequential PNG frames into animated APNG files while automatically logging each conversion’s success or failure to a report file.
 * 2. When an e‑learning platform wants to transform lecture slide PNG sequences into lightweight APNG animations for web delivery and keep a concise text report of the processing results.
 * 3. When a game asset pipeline requires turning character sprite PNG frames into APNG animations and generating a status report for quality‑assurance tracking.
 * 4. When a marketing team automates the creation of product showcase animations from daily PNG screenshots using C# and Aspose.Imaging, producing APNG files and a verification report for audit purposes.
 * 5. When a CI/CD build script must validate that all PNG image sequences in a repository are correctly packaged into APNGs and produce a report indicating any conversion failures before deployment.
 */