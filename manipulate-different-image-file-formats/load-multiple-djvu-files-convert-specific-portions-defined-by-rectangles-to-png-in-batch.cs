using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (Stream stream = File.OpenRead(filePath))
                {
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        int pageCount = djvuImage.PageCount;
                        for (int i = 0; i < pageCount; i++)
                        {
                            Rectangle exportArea = new Rectangle(0, 0, 200, 200);
                            PngOptions options = new PngOptions();
                            options.MultiPageOptions = new DjvuMultiPageOptions(i, exportArea);

                            string outputFileName = $"{Path.GetFileNameWithoutExtension(filePath)}_page{i}.png";
                            string outputPath = Path.Combine(outputDirectory, outputFileName);

                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            djvuImage.Save(outputPath, options);
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