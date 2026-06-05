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
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, jpegOptions);
            }

            if (File.Exists(outputPath))
            {
                long size = new FileInfo(outputPath).Length;
                if (size > 0)
                {
                    Console.WriteLine($"JPG file created successfully. Size: {size} bytes.");
                }
                else
                {
                    Console.Error.WriteLine("JPG file size is zero.");
                }
            }
            else
            {
                Console.Error.WriteLine("JPG file was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}