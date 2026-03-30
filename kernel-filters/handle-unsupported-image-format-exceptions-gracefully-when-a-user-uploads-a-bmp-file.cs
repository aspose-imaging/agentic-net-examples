using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/sample_converted.xyz";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath);
            }
        }
        catch (ArgumentException ex)
        {
            Console.Error.WriteLine($"Unsupported format: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}