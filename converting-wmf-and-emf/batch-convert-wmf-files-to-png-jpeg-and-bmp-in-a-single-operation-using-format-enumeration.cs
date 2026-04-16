using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input folder containing WMF files
        string inputFolder = @"C:\Images\WMF";

        // Ensure the input folder exists; if not, report and exit
        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Input folder not found: {inputFolder}");
            return;
        }

        // Retrieve all WMF files in the folder
        string[] wmfFiles = Directory.GetFiles(inputFolder, "*.wmf");

        // Process each WMF file
        foreach (string inputPath in wmfFiles)
        {
            // Verify the file exists (safety check)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare vector rasterization options based on the source image size
                var rasterizationOptions = new WmfRasterizationOptions { PageSize = image.Size };

                // Convert to PNG
                string pngOutput = Path.ChangeExtension(inputPath, ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutput));
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterizationOptions };
                image.Save(pngOutput, pngOptions);

                // Convert to JPEG
                string jpegOutput = Path.ChangeExtension(inputPath, ".jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(jpegOutput));
                var jpegOptions = new JpegOptions { VectorRasterizationOptions = rasterizationOptions };
                image.Save(jpegOutput, jpegOptions);

                // Convert to BMP
                string bmpOutput = Path.ChangeExtension(inputPath, ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(bmpOutput));
                var bmpOptions = new BmpOptions { VectorRasterizationOptions = rasterizationOptions };
                image.Save(bmpOutput, bmpOptions);
            }
        }
    }
}