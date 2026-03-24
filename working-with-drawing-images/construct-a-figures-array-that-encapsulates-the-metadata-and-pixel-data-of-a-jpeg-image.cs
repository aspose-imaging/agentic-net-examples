using System;
using System.IO;
using System.Text.Json;
using Aspose.Imaging.FileFormats.Jpeg;

namespace AsposeImagingExample
{
    // Represents metadata and pixel data of a JPEG image.
    public class Figure
    {
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Comment { get; set; }
        public byte[] ImageData { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths.
            string inputPath = @"C:\temp\sample.jpg";
            string outputPath = @"C:\temp\figures.json";

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image.
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Gather metadata.
                var figure = new Figure
                {
                    FileName = Path.GetFileName(inputPath),
                    Width = jpegImage.Width,
                    Height = jpegImage.Height,
                    Comment = jpegImage.Comment,
                    ImageData = File.ReadAllBytes(inputPath) // Raw JPEG bytes.
                };

                // Encapsulate into an array.
                Figure[] figures = new[] { figure };

                // Serialize the array to JSON and write to the output file.
                string json = JsonSerializer.Serialize(figures, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputPath, json);
            }
        }
    }
}