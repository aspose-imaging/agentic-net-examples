using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Define the crop rectangle (example values)
            var cropRect = new Aspose.Imaging.Rectangle(10, 10, 200, 200);
            image.Crop(cropRect);

            // Export the cropped image as APNG
            image.Save(outputPath, new ApngOptions());
        }
    }
}