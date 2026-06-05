using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.eps");

            if (files.Length == 0)
            {
                Console.WriteLine("No EPS files found in the input directory.");
                return;
            }

            Console.WriteLine("Enter target format (png, jpg, bmp, gif, tiff, pdf, webp):");
            string format = Console.ReadLine()?.Trim().ToLower();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string extension = format switch
                {
                    "png" => "png",
                    "jpg" => "jpg",
                    "jpeg" => "jpg",
                    "bmp" => "bmp",
                    "gif" => "gif",
                    "tiff" => "tiff",
                    "pdf" => "pdf",
                    "webp" => "webp",
                    _ => null
                };

                if (extension == null)
                {
                    Console.Error.WriteLine($"Unsupported format: {format}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "." + extension);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    switch (extension)
                    {
                        case "png":
                            image.Save(outputPath, new PngOptions());
                            break;
                        case "jpg":
                            image.Save(outputPath, new JpegOptions());
                            break;
                        case "bmp":
                            image.Save(outputPath, new BmpOptions());
                            break;
                        case "gif":
                            image.Save(outputPath, new GifOptions());
                            break;
                        case "tiff":
                            image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                            break;
                        case "pdf":
                            image.Save(outputPath, new PdfOptions());
                            break;
                        case "webp":
                            image.Save(outputPath, new WebPOptions());
                            break;
                    }
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}