// HOW-TO: Batch Convert PNG Sequences to Animated PNG with Status Report in C# (Aspose.Imaging for .NET)
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
            string inputRoot = "Input";
            string outputRoot = "Output";

            Directory.CreateDirectory(outputRoot);

            string[] sequenceDirs = Directory.GetDirectories(inputRoot);

            string reportPath = Path.Combine(outputRoot, "report.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            using (StreamWriter reportWriter = new StreamWriter(reportPath, true))
            {
                foreach (string seqDir in sequenceDirs)
                {
                    string sequenceName = Path.GetFileName(seqDir);
                    string[] pngFiles = Directory.GetFiles(seqDir, "*.png");
                    if (pngFiles.Length == 0)
                    {
                        reportWriter.WriteLine($"{sequenceName}: Failed - No PNG files found");
                        continue;
                    }

                    string firstPng = pngFiles[0];
                    if (!File.Exists(firstPng))
                    {
                        Console.Error.WriteLine($"File not found: {firstPng}");
                        return;
                    }

                    using (RasterImage firstImage = (RasterImage)Image.Load(firstPng))
                    {
                        int width = firstImage.Width;
                        int height = firstImage.Height;

                        string apngOutputPath = Path.Combine(outputRoot, sequenceName + ".png");
                        Directory.CreateDirectory(Path.GetDirectoryName(apngOutputPath));

                        ApngOptions options = new ApngOptions
                        {
                            Source = new FileCreateSource(apngOutputPath, false),
                            DefaultFrameTime = 100,
                            ColorType = PngColorType.TruecolorWithAlpha
                        };

                        using (ApngImage apngImage = (ApngImage)Image.Create(options, width, height))
                        {
                            apngImage.RemoveAllFrames();

                            foreach (string pngPath in pngFiles)
                            {
                                if (!File.Exists(pngPath))
                                {
                                    Console.Error.WriteLine($"File not found: {pngPath}");
                                    return;
                                }

                                using (RasterImage frame = (RasterImage)Image.Load(pngPath))
                                {
                                    apngImage.AddFrame(frame);
                                }
                            }

                            apngImage.Save();
                            reportWriter.WriteLine($"{sequenceName}: Success");
                        }
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

/*
 * Real-World Use Cases:
 * 1. When you need to automatically turn multiple folders of frame‑by‑frame PNG images into animated PNG files while generating a log of which conversions succeeded or failed.
 * 2. When an application must create APNG assets for a game or web UI from existing PNG sprite sheets and keep a text report for quality‑assurance tracking.
 * 3. When a server‑side service processes user‑uploaded PNG sequences in bulk, converts them to a single animated PNG, and records the outcome for auditing purposes.
 * 4. When a build pipeline has to generate animated PNG previews from design assets and output a summary file that developers can review for errors.
 * 5. When a digital‑media workflow requires converting large numbers of PNG frames to APNG format and storing a concise success/failure report for downstream processing.
 */
