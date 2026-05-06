using System;
using System.IO;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to JpegImage to access EXIF resolution data
                JpegImage jpeg = img as JpegImage;
                if (jpeg == null)
                {
                    Console.Error.WriteLine("The file is not a JPEG image.");
                    return;
                }

                // Read horizontal and vertical resolution from EXIF
                double horizontalResolution = jpeg.HorizontalResolution;
                double verticalResolution = jpeg.VerticalResolution;

                // Simulate storing in a database by writing to a text file
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