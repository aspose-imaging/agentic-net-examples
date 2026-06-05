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

            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                DateTime stepStart = DateTime.Now;
                Console.WriteLine($"Start processing '{inputPath}' at {stepStart:O}");

                using (Image image = Image.Load(inputPath))
                {
                    DateTime loadTime = DateTime.Now;
                    Console.WriteLine($"Loaded '{inputPath}' at {loadTime:O}");

                    image.Save(outputPath, new PngOptions());

                    DateTime saveTime = DateTime.Now;
                    Console.WriteLine($"Saved '{outputPath}' at {saveTime:O}");
                }

                DateTime stepEnd = DateTime.Now;
                Console.WriteLine($"Finished processing '{inputPath}' at {stepEnd:O}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}