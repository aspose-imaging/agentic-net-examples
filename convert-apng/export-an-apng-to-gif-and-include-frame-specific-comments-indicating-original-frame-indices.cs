using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Load(inputPath))
            {
                // Add a comment for each frame during export
                apng.PageExportingAction = (pageIndex, page) =>
                {
                    Console.WriteLine($"Exporting frame {pageIndex} (original index {pageIndex})");
                };

                GifOptions gifOptions = new GifOptions();
                apng.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}