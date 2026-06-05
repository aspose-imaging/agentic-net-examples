using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string extension = Path.GetExtension(inputPath).ToLowerInvariant();
                if (extension != ".odg" && extension != ".otg")
                {
                    // Skip unsupported files
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        if (extension == ".odg")
                        {
                            var rasterOptions = new OdgRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageSize = image.Size
                            };
                            pdfOptions.VectorRasterizationOptions = rasterOptions;
                        }
                        else // .otg
                        {
                            var rasterOptions = new OtgRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageSize = image.Size
                            };
                            pdfOptions.VectorRasterizationOptions = rasterOptions;
                        }

                        image.Save(outputPath, pdfOptions);
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