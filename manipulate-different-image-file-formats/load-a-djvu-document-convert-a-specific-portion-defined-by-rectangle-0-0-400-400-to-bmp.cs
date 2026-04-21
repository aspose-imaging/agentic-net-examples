using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DjVu document from file stream
        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvuImage = new DjvuImage(stream))
        {
            // Define the rectangle area to extract (0,0,400,400)
            Rectangle area = new Rectangle(0, 0, 400, 400);

            // Configure BMP save options with DjVu multi‑page options for the first page and the defined area
            BmpOptions bmpOptions = new BmpOptions
            {
                MultiPageOptions = new DjvuMultiPageOptions(0, area)
            };

            // Save the extracted portion as BMP
            djvuImage.Save(outputPath, bmpOptions);
        }
    }
}