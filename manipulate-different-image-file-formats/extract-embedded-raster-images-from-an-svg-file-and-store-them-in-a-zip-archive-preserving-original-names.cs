using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "extracted_images.zip";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var vectorImage = (VectorImage)image;
                var embeddedImages = vectorImage.GetEmbeddedImages();
                int index = 0;

                using (var zip = new System.IO.Compression.ZipArchive(File.Open(outputPath, FileMode.Create), System.IO.Compression.ZipArchiveMode.Create))
                {
                    foreach (var im in embeddedImages)
                    {
                        using (im)
                        {
                            string entryName = $"image{index++}.png";
                            var entry = zip.CreateEntry(entryName);
                            using (var entryStream = entry.Open())
                            {
                                im.Image.Save(entryStream, new PngOptions());
                            }
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