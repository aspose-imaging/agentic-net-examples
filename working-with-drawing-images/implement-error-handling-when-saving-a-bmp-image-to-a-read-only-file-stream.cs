using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/sample_readonly.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Ensure the output file exists and is marked read‑only
        using (FileStream temp = File.Create(outputPath)) { }
        File.SetAttributes(outputPath, FileAttributes.ReadOnly);

        using (Image image = Image.Load(inputPath))
        {
            var saveOptions = new BmpOptions();

            try
            {
                using (FileStream outStream = new FileStream(outputPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    image.Save(outStream, saveOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error saving image: {ex.Message}");
            }
        }
    }
}