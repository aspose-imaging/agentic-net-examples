using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.jpg";
            string outputPath = "resolution.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpegImage = image as JpegImage;
                if (jpegImage == null)
                {
                    Console.Error.WriteLine("The file is not a JPEG image.");
                    return;
                }

                double horizontalResolution = jpegImage.HorizontalResolution;
                double verticalResolution = jpegImage.VerticalResolution;

                string record = $"HorizontalResolution={horizontalResolution},VerticalResolution={verticalResolution}";
                File.WriteAllText(outputPath, record);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}